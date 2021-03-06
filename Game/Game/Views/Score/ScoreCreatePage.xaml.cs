using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Create Score
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScoreCreatePage : ContentPage
    {
        // The item to create
        public GenericViewModel<ScoreModel> ViewModel { get; set; }

        // Constructor for Unit Testing
        public ScoreCreatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public ScoreCreatePage(GenericViewModel<ScoreModel> data)
        {
            InitializeComponent();

            data.Data = new ScoreModel();

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Create Score";
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
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

            // If the Score Name and Score Value are not empty, allow Score Create
            if (!ScoreNameErrorMessage.IsVisible && !ScoreValueErrorMessage.IsVisible) {
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
        /// Check for valid Score Name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void NameText_Changed(object sender, TextChangedEventArgs args) {
            ScoreNameErrorMessage.IsVisible = false;

            if (String.IsNullOrEmpty(NameText.Text)) {
                ScoreNameErrorMessage.IsVisible = true;
            }
        
        }

        /// <summary>
        /// Check for valid Score Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Score_Value_Changed(object sender, TextChangedEventArgs args) {
            ScoreValueErrorMessage.IsVisible = false;

            if (String.IsNullOrEmpty(ScoreValue.Text))
            {
                ScoreValueErrorMessage.IsVisible = true;
            }
        }

    }
}