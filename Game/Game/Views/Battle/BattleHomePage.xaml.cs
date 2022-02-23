using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.Views.Battle;
using Game.Models;
using Game.ViewModels;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    public partial class BattleHomePage : ContentPage
    {
        // Empty Constructor for UTs
        bool UnitTestSetting;
        public BattleHomePage(bool UnitTest) { UnitTestSetting = UnitTest; }

        /// <summary>
        /// Constructor
        /// </summary>
        public BattleHomePage()
        {
            InitializeComponent();
            BindingContext = BattleEngineViewModel.Instance;
        }

        /// <summary>
        /// Button click will go to Pick characters page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Pick_Characters_Page_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickCharactersPage());
        }

        /// <summary>
        /// Button click will go to Begin battle page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Begin_Battle_Page_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BattleEntryPage());
        }

        /// <summary>
        /// Button click will go to Pick Items page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Pick_Items_Page_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PickItemsPage());
        }

        /// <summary>
        /// Button click will go to Battle Entry page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Battle_Entry_Page_Clicked(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Button click will go to Battle Field page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Battle_Field_Page_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BattleFieldPage());
        }

        /// <summary>
        /// Button click will go to Battle Sequence page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Battle_Sequence_Page_Clicked(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Button click will go to Game Over page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Game_Over_Page_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GameOverPage());
        }
    }
}