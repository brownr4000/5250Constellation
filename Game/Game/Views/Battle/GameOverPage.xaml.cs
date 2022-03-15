using System;
using System.Collections.Generic;
using Game.ViewModels;
using Game.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Battle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameOverPage : ContentPage
    {
        ScoreModel scoreList = new ScoreModel();

        // Empty Constructor for UTs
        bool UnitTestSetting;
        public GameOverPage(bool UnitTest) { UnitTestSetting = UnitTest; }

        /// <summary>
        /// Constructor for GameOverPage
        /// </summary>
        public GameOverPage()
        {
            InitializeComponent();

            // Start from a clean list of players
            BattleEngineViewModel.Instance.PartyCharacterList.Clear();
            BattleEngineViewModel.Instance.Engine.EngineSettings.PlayerList.Clear();

            // Rest RoundCount
            BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore.RoundCount = 0;

            scoreList = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore; 
        }

        /// <summary>
        /// View Result button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ViewResult_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ScoreReadPage(new GenericViewModel<ScoreModel>(scoreList)));
        }
    }
}