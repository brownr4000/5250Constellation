using Game;
using Game.Models;
using Game.ViewModels;
using Game.Views.Battle;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace UnitTests.Views.Battle
{
    [TestFixture]
    public class ItemSelectionPageTests : ItemSelectionPage
    {
        App app;
        ItemSelectionPage page;


        public ItemSelectionPageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;
            List<ItemModel> itemList = new List<ItemModel>();

            page = new ItemSelectionPage(itemList);

        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void ItemSelectionTests_Default_Should_Pass()
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