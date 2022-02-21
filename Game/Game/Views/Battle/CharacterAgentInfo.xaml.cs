using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.Models;
using Game.ViewModels;
using System.Linq;
using Game.Views.Battle;

namespace Game.Views
{
    /// <summary>
    /// Selecting Characters for the Game
    /// 
    /// TODO: Team
    /// Mike's game allows duplicate characters in a party (6 Mikes can all fight)
    /// If you do not allow duplicates, change the code below
    /// Instead of using the database list directly make a copy of it in the viewmodel
    /// Then have on select of the database remove the character from that list and add to the part list
    /// Have select from the party list remove it from the party list and add it to the database list
    ///
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0019:Use pattern matching", Justification = "<Pending>")]
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterAgentInfoPage : ContentPage
    {
        private GenericViewModel<CharacterModel> ViewModel;

        // Empty Constructor for UTs
      //  public CharacterAgentInfoPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Index Page
        /// 
        /// Get the CharacterIndexView Model
        /// </summary>
        public CharacterAgentInfoPage()
        {
            InitializeComponent();

            BindingContext = BattleEngineViewModel.Instance;

            // Clear the Database List and the Party List to start
            BattleEngineViewModel.Instance.PartyCharacterList.Clear();
        }

        /// <summary>
        /// Constructor for Index Page accepting data
        /// 
        /// Get the CharacterIndexView Model
        /// </summary>
        public CharacterAgentInfoPage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;
        }

        /// <summary>
        /// Cancel button clicked goes to index page without selecting  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickCharactersPage());
        }

        /// <summary>
        /// Next button clicked selects the character and goes back to index page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Select_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickCharactersPage());
        }

        private void LeftImageButton_Clicked(object sender, EventArgs e)
        {

        }

        private void RightImageButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}