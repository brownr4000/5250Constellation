using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
