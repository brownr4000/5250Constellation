using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game;
using Game.ViewModels;
using Game.Views.Battle;
using NUnit.Framework;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace UnitTests.Views.Battle
{
    [TestFixture]
    public class GameOverPageTests : GameOverPage
    {
        App app;
        GameOverPage page;

        public GameOverPageTests() : base(true){}

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new GameOverPage();

            //Start the Engine in AutoBattle Mode
            _ = BattleEngineViewModel.Instance.Engine.EndBattle();
           

        }


        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void GameOverPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void GameOverPage_ViewResult_Clicked_Default_Should_Pass()
        {

            // Act
            page.ViewResult_Clicked(null,null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}