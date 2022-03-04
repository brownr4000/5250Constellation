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

        public GameOverPage()
        {
            InitializeComponent();
            scoreList = BattleEngineViewModel.Instance.Engine.EngineSettings.BattleScore; 
        }

        public async void ViewResult_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ScoreReadPage(new GenericViewModel<ScoreModel>(scoreList)));
        }
    }
}