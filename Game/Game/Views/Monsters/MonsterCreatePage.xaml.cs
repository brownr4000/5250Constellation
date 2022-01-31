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

            // Hiding error messages
            NameErrorMessage.IsVisible = false;
            DescErrorMessage.IsVisible = false;
            ClassErrorMessage.IsVisible = false;

            // Load the values for the Class into the Picker
            ClassPicker.Items.Add(MonsterJobEnum.Fighter.ToMessage());
            ClassPicker.Items.Add(MonsterJobEnum.Cleric.ToMessage());
            ClassPicker.Items.Add(MonsterJobEnum.Support.ToMessage());

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

            MessagingCenter.Send(this, "Create", ViewModel.Data);
            _ = await Navigation.PopModalAsync();
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

        private void UniqueItemPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    }
}