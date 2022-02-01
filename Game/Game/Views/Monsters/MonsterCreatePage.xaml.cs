using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.Models;
using Game.ViewModels;

namespace Game.Views
{
    /// <summary>
    /// Create Monster
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterCreatePage : ContentPage
    {
        // The Monster to create
        public GenericViewModel<MonsterModel> ViewModel { get; set; }

        // The view model for items
        readonly ItemIndexViewModel ItemsViewModel = ItemIndexViewModel.Instance;

        // Hold the current location selected
        public ItemLocationEnum PopupLocationEnum = ItemLocationEnum.Unknown;

        // Empty Constructor for UTs
        public MonsterCreatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public MonsterCreatePage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            data.Data = new MonsterModel();
            this.ViewModel = data;
            this.ViewModel.Title = "Create";

            // Adding items to Unique picker
            var itemsData = ItemsViewModel;
            foreach (var item in itemsData.Dataset)
            {
                UniqueItemPicker.Items.Add(item.Name);
            }            

            // Hiding error messages
            NameErrorMessage.IsVisible = false;
            DescErrorMessage.IsVisible = false;
            ClassErrorMessage.IsVisible = false;
            DifficultyErrorMessage.IsVisible = false;
            ExperienceErrorMessage.IsVisible = false;

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

            // Load Item values to UniquePicker
            //foreach(var item in ItemViewModel.)
            //{

            //}
            //UniqueItemPicker.Items.Add(ItemViewModel.Data)

            _ = UpdatePageBindingContext();
        }

        /// <summary>
        /// Redo the Binding to cause a refresh
        /// </summary>
        /// <returns></returns>
        public bool UpdatePageBindingContext()
        {
            // Temp store off the difficulty
            var difficulty = this.ViewModel.Data.Difficulty;

            // Clear the Binding and reset it
            BindingContext = null;
            BindingContext = this.ViewModel;

            ViewModel.Data.Difficulty = difficulty;

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

            // Checking Experience value is not empty
            //if (string.IsNullOrEmpty(ExperienceValue.Text))
            //{
            //    ExperienceErrorMessage.Text = ExperienceErrorMessage.Text + "Please enter value for Experience";
            //    ExperienceErrorMessage.IsVisible = true;
            //}

            //// Checking valid input for Experience
            //if (!string.IsNullOrEmpty(ExperienceValue.Text) && !Int32.TryParse(ExperienceValue.Text, out int parsedInt))
            //{
            //    ExperienceErrorMessage.Text = ExperienceErrorMessage.Text + " Please enter valid Experience value";
            //    ExperienceErrorMessage.IsVisible = true;
            //}

            if (!NameErrorMessage.IsVisible && !ExperienceErrorMessage.IsVisible && !DescErrorMessage.IsVisible && !ClassErrorMessage.IsVisible  && !DifficultyErrorMessage.IsVisible)
            {
                MessagingCenter.Send(this, "Create", ViewModel.Data);
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
        /// On change event of Speed stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Health_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            HealthValue.Text = string.Format("{0}", e.NewValue);
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

        private void UniqueItemPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// Difficulty picker change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void DifficultyPicker_SelectedIndexChanged(object sender, EventArgs e)
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
            switch (selectedClass)
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
        /// On change event of Experience
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExperienceValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            ExperienceErrorMessage.IsVisible = false;
            ExperienceOverflowErrorMessage.IsVisible = false;
            
            if (string.IsNullOrEmpty(ExperienceValue.Text))
            {
                ExperienceErrorMessage.IsVisible = true;
                ExperienceErrorMessage.Text = "Please enter the Experience";
            }            

            // Checking valid input for Experience
            else if(!string.IsNullOrEmpty(ExperienceValue.Text) && !Int32.TryParse(ExperienceValue.Text, out int parsedInt))
            {
                ExperienceErrorMessage.Text = "Please enter valid Experience value";
                ExperienceErrorMessage.IsVisible = true;                
            }

            else if (int.Parse(ExperienceValue.Text) > 500 || int.Parse(ExperienceValue.Text) < 0)
            {
                ExperienceOverflowErrorMessage.IsVisible = true;
                ExperienceOverflowErrorMessage.Text = "The Experience value can only be between 0 and 500";
            }
        }
    }
}