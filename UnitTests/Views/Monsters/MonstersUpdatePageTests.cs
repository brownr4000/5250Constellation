using NUnit.Framework;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace UnitTests.Views
{
    [TestFixture]
    public class MonsterUpdatePageTests : MonsterUpdatePage
    {
        App app;
        MonsterUpdatePage page;

        public MonsterUpdatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new MonsterUpdatePage(new GenericViewModel<MonsterModel>(new MonsterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void MonsterUpdatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterUpdatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_Save_Clicked_Null_Image_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data.ImageURI = null;

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            _ = OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterUpdatePage_DifficultyPicker_SelectedIndexChanged_Easy_Valid_Should_Pass()
        {
            // Arrange
            var selectedDificulty = (Picker)page.FindByName("DifficultyPicker");
            selectedDificulty.SelectedItem = "Easy";

            // Act
            page.DifficultyPicker_SelectedIndexChanged(selectedDificulty, null);
            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterUpdatePage_DifficultyPicker_SelectedIndexChanged_Average_Valid_Should_Pass()
        {
            // Arrange
            var selectedDificulty = (Picker)page.FindByName("DifficultyPicker");
            selectedDificulty.SelectedItem = "Average";

            // Act
            page.DifficultyPicker_SelectedIndexChanged(selectedDificulty, null);
            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterUpdatePage_DifficultyPicker_SelectedIndexChanged_Hard_Valid_Should_Pass()
        {
            // Arrange
            var selectedDificulty = (Picker)page.FindByName("DifficultyPicker");
            selectedDificulty.SelectedItem = "Hard";

            // Act
            page.DifficultyPicker_SelectedIndexChanged(selectedDificulty, null);
            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterUpdatePage_DifficultyPicker_SelectedIndexChanged_Impossible_Valid_Should_Pass()
        {
            // Arrange
            var selectedDificulty = (Picker)page.FindByName("DifficultyPicker");
            selectedDificulty.SelectedItem = "Impossible";

            // Act
            page.DifficultyPicker_SelectedIndexChanged(selectedDificulty, null);
            // Reset

            // Assert
            Assert.IsTrue(true);
        }


        [Test]
        public void MonsterUpdatePage_DifficultyPicker_SelectedIndexChanged_Difficult_Valid_Should_Pass()
        {
            // Arrange
            var selectedDificulty = (Picker)page.FindByName("DifficultyPicker");
            selectedDificulty.SelectedItem = "Difficult";

            // Act
            page.DifficultyPicker_SelectedIndexChanged(selectedDificulty, null);
            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterUpdatePage_DifficultyPicker_SelectedIndexChanged_Invalid_Should_Pass()
        {
            // Arrange
            var selectedDifficulty = (Picker)page.FindByName("DifficultyPicker");
            selectedDifficulty.SelectedItem = null;

            // Act
            page.DifficultyPicker_SelectedIndexChanged(selectedDifficulty, null);

            // Reset

            // Assert
            Assert.IsTrue(true);

        }

        [Test]
        public void MonsterUpdatePage_Class_Changed_Valid_Should_Pass()
        {
            // Arrange
            var selectedClass = (Picker)page.FindByName("ClassPicker");
            selectedClass.SelectedItem = null;

            // Act
            page.Class_Changed(selectedClass, null);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }
    }
}