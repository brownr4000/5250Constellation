using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace Game.Views.Battle
{
    [TestFixture]
    public class BattleMessagesPageTests: BattleMessagesPage
    {
        App app;
        BattleMessagesPage page;

        public BattleMessagesPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new BattleMessagesPage();

        }


        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void BattleMessagesPage_Constructor_Default_Should_Pass()
        {
            // Arrange
            var result = page;

            // Act

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
