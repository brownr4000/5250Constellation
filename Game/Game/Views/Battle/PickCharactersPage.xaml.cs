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
    public partial class PickCharactersPage : ContentPage
    {
        // The view model, used for data binding
        readonly CharacterIndexViewModel ViewModel = CharacterIndexViewModel.Instance;

        // Empty Constructor for UTs
        public PickCharactersPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Index Page
        /// 
        /// Get the CharacterIndexView Model
        /// </summary>
        public PickCharactersPage()
        {  
            InitializeComponent();
            ErrorMessage.IsVisible = false;
            BindingContext = ViewModel;
        }        

        /// <summary>
        /// On Character selected go to Agent Info page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public async void CharacterListView_SelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            ErrorMessage.IsVisible = false;
            CharacterModel data = args.CurrentSelection.FirstOrDefault() as CharacterModel;           
           
            // Open the Agent info Page
            await Navigation.PushAsync(new CharacterAgentInfoPage(new GenericViewModel<CharacterModel>(data), ViewModel));
        }

        /// <summary>
        /// Save button loads characters list and takes to next page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if(BattleEngineViewModel.Instance.PartyCharacterList.Count == 0)
            {
                ErrorMessage.IsVisible = true;
                return;
            }
            
            if(BattleEngineViewModel.Instance.PartyCharacterList.Count != 0)
            {
                // Load the Characters into the Engine
                foreach (var data in BattleEngineViewModel.Instance.PartyCharacterList)
                {
                    data.CurrentHealth = data.GetMaxHealthTotal;
                    BattleEngineViewModel.Instance.Engine.EngineSettings.CharacterList.Add(new PlayerInfoModel(data));
                }

                ErrorMessage.IsVisible = false;
                await Navigation.PushModalAsync(new NavigationPage(new NewRoundPage()));
                _ = await Navigation.PopAsync();
            }            
        }
    }
}