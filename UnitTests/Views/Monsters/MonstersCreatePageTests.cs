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
    public class MonsterCreatePageTests : MonsterCreatePage
    {
        App app;
        MonsterCreatePage page;

        public MonsterCreatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new MonsterCreatePage(new GenericViewModel<MonsterModel>(new MonsterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void MonsterCreatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void MonsterCreatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void MonsterCreatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            _ = OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void MonsterCreatePage_DifficultyPicker_SelectedIndexChanged_Valid_Easy_Should_Pass()
        {
            // Arrange
            var selectedDifficulty = (Picker)page.FindByName("DifficultyPicker");

            // Act
            selectedDifficulty.SelectedIndex = 0;

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterCreatePage_DifficultyPicker_SelectedIndexChanged_Valid_Average_Should_Pass()
        {
            // Arrange
            var selectedDifficulty = (Picker)page.FindByName("DifficultyPicker");

            // Act
            selectedDifficulty.SelectedIndex = 1;

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterCreatePage_DifficultyPicker_SelectedIndexChanged_Valid_Hard_Should_Pass()
        {
            // Arrange
            var selectedDifficulty = (Picker)page.FindByName("DifficultyPicker");

            // Act
            selectedDifficulty.SelectedIndex = 2;

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterCreatePage_DifficultyPicker_SelectedIndexChanged_Valid_Impossible_Should_Pass()
        {
            // Arrange
            var selectedDifficulty = (Picker)page.FindByName("DifficultyPicker");

            // Act
            selectedDifficulty.SelectedIndex = 4;

            // Reset

            // Assert
            Assert.IsTrue(true);
        }


        [Test]
        public void MonsterCreatePage_DifficultyPicker_SelectedIndexChanged_Valid_Difficult_Should_Pass()
        {
            // Arrange
            var selectedDifficulty = (Picker)page.FindByName("DifficultyPicker");

            // Act
            selectedDifficulty.SelectedIndex = 3;

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterCreatePage_DifficultyPicker_SelectedIndexChanged_InValid_Should_Pass()
        {
            // Arrange
            var selectedDifficulty = (Picker)page.FindByName("DifficultyPicker");

            // Act
            page.DifficultyPicker_SelectedIndexChanged(selectedDifficulty, null);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterCreatePage_ClassPicker_SelectedIndexChanged_InValid_Should_Pass()
        {
            // Arrange
            var selectedClass = (Picker)page.FindByName("ClassPicker");

            // Act
            page.ClassPicker_SelectedIndexChanged(selectedClass, null);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterCreatePage_ClassPicker_SelectedIndexChanged_Brute_Valid_Should_Pass()
        {
            // Arrange
            var selectedClass = (Picker)page.FindByName("ClassPicker");

            // Act
            selectedClass.SelectedIndex = 0;

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterCreatePage_ClassPicker_SelectedIndexChanged_Swift_Valid_Should_Pass()
        {
            // Arrange
            var selectedClass = (Picker)page.FindByName("ClassPicker");

            // Act
            selectedClass.SelectedIndex = 1;

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterCreatePage_ClassPicker_SelectedIndexChanged_Clever_Valid_Should_Pass()
        {
            // Arrange
            var selectedClass = (Picker)page.FindByName("ClassPicker");

            // Act
            selectedClass.SelectedIndex = 2;

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterCreatePage_DescriptionValue_TextChanged_Valid_Should_Pass()
        {
            // Arrange
            var desc = (Entry)page.FindByName("DescValue");
            desc.Text = null;

            // Act

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonsterCreatePage_NameValue_TextChanged_Invalid_Should_Pass()
        {

            // Arrange
            var entry = (Entry)page.FindByName("NameValue");
            entry.Text = null;

            var textChanged = new TextChangedEventArgs(entry.Text,null);

            // Act
            page.NameValue_TextChanged(null,textChanged);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonstersCreatePage_SaveClicked_Valid_Should_Pass()
        {
            // Arrange
            var name = (Entry)page.FindByName("NameValue");
            name.Text = "name";
            var desc = (Entry)page.FindByName("DescValue");
            desc.Text = "desc";
            var Class = (Picker)page.FindByName("ClassPicker");
            Class.SelectedItem = MonsterJobEnum.Clever;
            var difficulty = (Picker)page.FindByName("DifficultyPicker");
            difficulty.SelectedItem = DifficultyEnum.Difficult;

            // Act
            page.Save_Clicked(null,null);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        [Test]
        public void MonstersCreatePageTests_RandomizeCharacter()
        {
            // Arrange

            // Act
            page.RandomizeCharacter();

            // Reset

            // Assert
            Assert.IsTrue(true);

        }
    }
}