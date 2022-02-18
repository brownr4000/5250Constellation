using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// Monster Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterUpdatePage : ContentPage
    {
        //Hold a copy of data
        public MonsterModel DataCopy;

        // The Monster to create
        public GenericViewModel<MonsterModel> ViewModel { get; set; }

        // The view model for items
        readonly ItemIndexViewModel ItemsViewModel = ItemIndexViewModel.Instance;

        // Hold the current location selected
        public ItemLocationEnum PopupLocationEnum = ItemLocationEnum.Unknown;

        // Empty Constructor for UTs
        public MonsterUpdatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public MonsterUpdatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            //Copy of Character to restore for cancel
            DataCopy = new MonsterModel(data.Data);

            // Hiding error messages
            NameErrorMessage.IsVisible = false;
            DescErrorMessage.IsVisible = false;
            ClassErrorMessage.IsVisible = false;
            DifficultyErrorMessage.IsVisible = false;

            // Load items to Unique picker
            var itemsData = ItemsViewModel;
            foreach (var item in itemsData.Dataset)
            {
                UniqueItemPicker.Items.Add(item.Name);               
            }
                       
            // Load the values for the Class into the Picker
            ClassPicker.Items.Add(MonsterJobEnum.Fighter.ToMessage());
            ClassPicker.Items.Add(MonsterJobEnum.Cleric.ToMessage());
            ClassPicker.Items.Add(MonsterJobEnum.Support.ToMessage());

            // Load the values for the Dificulty into the Picker
            DifficultyPicker.Items.Add(DifficultyEnum.Easy.ToMessage());
            DifficultyPicker.Items.Add(DifficultyEnum.Average.ToMessage());
            DifficultyPicker.Items.Add(DifficultyEnum.Hard.ToMessage());
            DifficultyPicker.Items.Add(DifficultyEnum.Difficult.ToMessage());
            DifficultyPicker.Items.Add(DifficultyEnum.Impossible.ToMessage());

            _ = UpdatePageBindingContext();
        }

        /// <summary>
        /// Redo the Binding to cause a refresh
        /// </summary>
        /// <returns></returns>
        public bool UpdatePageBindingContext()
        {
            // Temp store off the Difficulty
            var difficulty = this.ViewModel.Data.Difficulty;

            // Clear the Binding and reset it
            BindingContext = null;
            BindingContext = this.ViewModel;

            //Converting Job to Class and assigning to ClassPicker            
            ConverClasstoJob(ViewModel.Data.MonsterJob);

            ConvertDifficultytoDifficultyEnum(difficulty);

            AssignUniquePickerSelectedItem();

            return true;
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = new MonsterModel().ImageURI;
            }

            // Set unique item selected to View Model
            ViewModel.Data.UniqueItem = UniqueItemPicker.SelectedItem != null ? UniqueItemPicker.SelectedItem.ToString() : null;

            // Checking if Class picker has value selected
            if (ClassPicker.SelectedItem == null)
            {
                ClassErrorMessage.IsVisible = true;
                ClassErrorMessage.Text = "Please select a Class";
            }

            // Checking if Difficulty picker has value selected
            if (DifficultyPicker.SelectedItem == null)
            {
                DifficultyErrorMessage.IsVisible = true;
                DifficultyErrorMessage.Text = "Please select a Difficulty level";
            }

            if (!NameErrorMessage.IsVisible && !DescErrorMessage.IsVisible && !ClassErrorMessage.IsVisible && !DifficultyErrorMessage.IsVisible)
            {
                MessagingCenter.Send(this, "Update", ViewModel.Data);
                _ = await Navigation.PopModalAsync();
            }            
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            // Use the copy
            ViewModel.Data.Update(DataCopy);

            _ = await Navigation.PopModalAsync();
        }

        /// <summary>
        /// Name change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameErrorMessage.IsVisible = false;
            if (string.IsNullOrEmpty(NameValue.Text))
            {
                NameErrorMessage.IsVisible = true;
            }
        }

        /// <summary>
        /// On change event of Attack stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttackStepper_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            AttackValue.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// On change event of Defense stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Defense_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            DefenseValue.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// On change event of Speed stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Speed_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            SpeedValue.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Description change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DescriptionValue_TextChanged(object sender, ValueChangedEventArgs e)
        {
            DescErrorMessage.IsVisible = false;
            if (string.IsNullOrEmpty(DescValue.Text))
            {
                DescErrorMessage.IsVisible = true;
            }
        }        

        /// <summary>
        /// Difficulty picker change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DifficultyPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDifficulty = DifficultyPicker.SelectedItem;
            if (selectedDifficulty != null)
            {
                DifficultyErrorMessage.IsVisible = false;
            }

            // Convert difficulty based on selected value
            switch (selectedDifficulty)
            {
                case "Easy":
                    ViewModel.Data.Difficulty = DifficultyEnum.Easy;
                    break;
                case "Average":
                    ViewModel.Data.Difficulty = DifficultyEnum.Average;
                    break;
                case "Hard":
                    ViewModel.Data.Difficulty = DifficultyEnum.Hard;
                    break;
                case "Impossible":
                    ViewModel.Data.Difficulty = DifficultyEnum.Impossible;
                    break;
                case "Difficult":
                    ViewModel.Data.Difficulty = DifficultyEnum.Difficult;
                    break;
                default:
                    break;
            }
        }
        
        /// <summary>
        /// Assign Unique Picker selected Item value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AssignUniquePickerSelectedItem()
        {
            if (!string.IsNullOrEmpty(ViewModel.Data.UniqueItem))
            {
                UniqueItemPicker.SelectedItem = ViewModel.Data.UniqueItem;
            }            
        }

        /// <summary>
        /// The Level selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Class_Changed(object sender, EventArgs args)
        {
            var selectedClass = ClassPicker.SelectedItem;
            if (selectedClass != null)
            {
                ClassErrorMessage.IsVisible = false;
            }
            // Change the Class
            ConverJobtoClass(selectedClass);
        }

        /// <summary>
        /// Convert job enum to class
        /// </summary>
        /// <param name="selectedJob"></param>
        public void ConverJobtoClass(object selectedJob)
        {
            switch (selectedJob)
            {
                case "Tank":
                    ViewModel.Data.MonsterJob = MonsterJobEnum.Fighter;
                    break;
                case "Damage":
                    ViewModel.Data.MonsterJob = MonsterJobEnum.Cleric;
                    break;
                case "Support":
                    ViewModel.Data.MonsterJob = MonsterJobEnum.Support;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Convert Class to Job enum values
        /// </summary>
        /// <param name="selectedClass"></param>
        public void ConverClasstoJob(object selectedClass)
        {
            switch (selectedClass.ToString())
            {
                case "Fighter":
                    ClassPicker.SelectedItem = MonsterJobEnum.Fighter.ToMessage();
                    break;
                case "Cleric":
                    ClassPicker.SelectedItem = MonsterJobEnum.Cleric.ToMessage();
                    break;
                case "Support":
                    ClassPicker.SelectedItem = MonsterJobEnum.Support.ToMessage();
                    break;
                default:
                    break;
            }            
        }

        /// <summary>
        /// Convert difficulty value to enum value
        /// </summary>
        /// <param name="selectedClass"></param>
        public void ConvertDifficultytoDifficultyEnum(object selectedValue)
        {
            switch (selectedValue.ToString())
            {
                case "Easy":
                    DifficultyPicker.SelectedItem = DifficultyEnum.Easy.ToMessage();
                    break;
                case "Average":
                    DifficultyPicker.SelectedItem = DifficultyEnum.Average.ToMessage();
                    break;
                case "Hard":
                    DifficultyPicker.SelectedItem = DifficultyEnum.Hard.ToMessage();
                    break;
                case "Difficult":
                    DifficultyPicker.SelectedItem = DifficultyEnum.Difficult.ToMessage();
                    break;
                case "Impossible":
                    DifficultyPicker.SelectedItem = DifficultyEnum.Impossible.ToMessage();
                    break;                
                default:
                    break;
            }            
        }

        /// <summary>
        /// The Class selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClassPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedClass = ClassPicker.SelectedItem;
            if (selectedClass != null)
            {
                ClassErrorMessage.IsVisible = false;
            }

            // Convert class based on selected value
            ConverJobtoClass(selectedClass);
        }        
    }
}