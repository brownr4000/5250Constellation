using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.Models;
using Game.GameRules;
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

            // Load items to Unique picker
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

            // Load the values for the Class into the Picker
            ClassPicker.Items.Add(MonsterJobEnum.Brute.ToMessage());
            ClassPicker.Items.Add(MonsterJobEnum.Swift.ToMessage());
            ClassPicker.Items.Add(MonsterJobEnum.Clever.ToMessage());
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

            if (!NameErrorMessage.IsVisible 
                && !DescErrorMessage.IsVisible &&
                !ClassErrorMessage.IsVisible && !DifficultyErrorMessage.IsVisible)
            {
                MessagingCenter.Send(this, "Create", ViewModel.Data);
                _ = await Navigation.PopModalAsync();
            }
        }

        /// <summary>
        /// Randomize Character Values and Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RollDice_Clicked(object sender, EventArgs e)
        {
            _ = RandomizeCharacter();
            return;
        }

        /// <summary>
        /// 
        /// Randomize the Character
        /// Keep the Level the Same
        /// 
        /// </summary>
        /// <returns></returns>
        public bool RandomizeCharacter()
        {
            // Randomize Name
            ViewModel.Data.Name = RandomPlayerHelper.GetMonsterName();
            ViewModel.Data.Description = RandomPlayerHelper.GetMonsterDescription();

            ViewModel.Data.ImageURI = RandomPlayerHelper.GetMonsterImage();

            _ = UpdatePageBindingContext();

            return true;
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
        /// UniqueItem picker change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UniqueItemPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewModel.Data.UniqueItem = UniqueItemPicker.SelectedItem.ToString();
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
        /// The Class selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClassPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedClass = ClassPicker.SelectedItem;
            if (selectedClass != null)
            {
                ClassErrorMessage.IsVisible = false;
            }

            // Convert class based on selected value
            switch (selectedClass)
            {
                case "Brute":
                    ViewModel.Data.MonsterJob = MonsterJobEnum.Brute;
                    break;
                case "Swift":
                    ViewModel.Data.MonsterJob = MonsterJobEnum.Swift;
                    break;
                case "Support":
                    ViewModel.Data.MonsterJob = MonsterJobEnum.Support;
                    break;
                case "Clever":
                    ViewModel.Data.MonsterJob = MonsterJobEnum.Clever;
                    break;
                default:
                    break;
            }
        }
    }
}