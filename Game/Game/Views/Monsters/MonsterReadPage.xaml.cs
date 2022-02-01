using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;

namespace Game.Views
{
    /// <summary>
    /// The Read Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonsterReadPage : ContentPage
    {
        // View Model for Monster
        public readonly GenericViewModel<MonsterModel> ViewModel;

        // Empty Constructor for UTs
        public MonsterReadPage(bool UnitTest) { }

        /// <summary>
        /// Constructor called with a view model
        /// This is the primary way to open the page
        /// The viewModel is the data that should be displayed
        /// </summary>
        /// <param name="viewModel"></param>
        public MonsterReadPage(GenericViewModel<MonsterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;

            //Converting Job to Class and assigning to ClassPicker
            string result = ConverClasstoJob(ViewModel.Data.Job);
            if (!string.IsNullOrEmpty(result))
            {
                ClassValue.Text = result;
            }
        }

        /// <summary>
        /// Convert Class to Job
        /// </summary>
        /// <param name="selectedClass"></param>
        public string ConverClasstoJob(object selectedClass)
        {
            string result = null;
            switch (selectedClass.ToString())
            {
                case "Fighter":
                    result = CharacterJobEnum.Fighter.ToMessage();
                    break;
                case "Cleric":
                    result = CharacterJobEnum.Cleric.ToMessage();
                    break;
                case "Support":
                    result = CharacterJobEnum.Support.ToMessage();
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Update_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterUpdatePage(ViewModel)));
            _ = await Navigation.PopAsync();
        }

        /// <summary>
        /// Calls for Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Delete_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new MonsterDeletePage(ViewModel)));
            _ = await Navigation.PopAsync();
        }
    }
}