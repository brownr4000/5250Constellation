using NUnit.Framework;
using System.Linq;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace UnitTests.Views
{
    [TestFixture]
    public class CharacterCreatePageTests : CharacterCreatePage
    {
        App app;
        CharacterCreatePage page;

        public CharacterCreatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new CharacterCreatePage(new GenericViewModel<CharacterModel>(new CharacterModel()));
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void CharacterCreatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterCreatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void CharacterCreatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            _ = OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Attack_OnStepperAttackChanged_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);

            page = new CharacterCreatePage(ViewModel);
            var oldAttack = 0.0;
            var newAttack = 1.0;

            var args = new ValueChangedEventArgs(oldAttack, newAttack);

            // Act
            page.Attack_OnStepperValueChanged(null, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Speed_OnStepperValueChanged_Default_Should_Pass()
        {
            // ArSpeed
            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);

            page = new CharacterCreatePage(ViewModel);
            var oldSpeed = 0.0;
            var newSpeed = 1.0;

            var args = new ValueChangedEventArgs(oldSpeed, newSpeed);

            // Act
            page.Speed_OnStepperValueChanged(null, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Defense_OnStepperDefenseChanged_Default_Should_Pass()
        {
            // Arrange
            var data = new CharacterModel();
            var ViewModel = new GenericViewModel<CharacterModel>(data);

            page = new CharacterCreatePage(ViewModel);
            var oldDefense = 0.0;
            var newDefense = 1.0;

            var args = new ValueChangedEventArgs(oldDefense, newDefense);

            // Act
            page.Defense_OnStepperValueChanged(null, args);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_RollDice_Clicked_Default_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data = new CharacterModel();

            // Act
            page.RollDice_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClosePopup_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ClosePopup_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.ClosePopup_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_ShowPopup_Default_Should_Pass()
        {
            // Arrange
            page.ViewModel.Data = new CharacterModel();

            // Act
            _ = page.ShowPopup(ItemLocationEnum.PrimaryHand);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnPopupItemSelected_Clicked_Default_Should_Pass()
        {
            // Arrange

            var data = new ItemModel();

            var selectedCharacterChangedEventArgs = new SelectedItemChangedEventArgs(data, 0);

            // Act
            page.OnPopupItemSelected(null, selectedCharacterChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_OnPopupItemSelected_Clicked_Null_Should_Fail()
        {
            // Arrange

            var selectedCharacterChangedEventArgs = new SelectedItemChangedEventArgs(null, 0);

            // Act
            page.OnPopupItemSelected(null, selectedCharacterChangedEventArgs);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCreatePage_Item_ShowPopup_Default_Should_Pass()
        {
            // Arrange

            var item = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);

            // Act
            var itemButton = item.Children.FirstOrDefault(m => m.GetType().Name.Equals("Button"));

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterCratePage_GetItemToDisplay_Click_Button_Valid_Should_Pass()
        {
            // Arrange
            var item = ItemIndexViewModel.Instance.GetDefaultItem(ItemLocationEnum.PrimaryHand);
            page.ViewModel.Data.Head = item.Id;
            var StackItem = page.GetItemToDisplay(ItemLocationEnum.PrimaryHand);
            var dataImage = StackItem.Children[0];

            // Act
            ((ImageButton)dataImage).PropagateUpClicked();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        /// <summary>
        /// Tests the Location_Changed Event
        /// </summary>
        [Test]
        public void CharacterCreatePage_Location_Changed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            Location_Changed(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Tests the Name_TextChanged Error Message Display
        /// </summary>
        [Test]
        public void CharacterCreatePage_Name_TextChanged_Invalid_Should_Pass()
        {
            // Arrange
            var entry = (Entry)page.FindByName("NameValue");

            entry.Text = null;

            var textChanged = new TextChangedEventArgs(entry.Text, null);

            // Act
            page.Name_TextChanged(null, textChanged);
            
            // Reset

            // Assert
            Assert.IsTrue(true);

        }

        /// <summary>
        /// Tests the Desc_TextChanged Error Message Display
        /// </summary>
        [Test]
        public void CharacterCreatePage_Desc_TextChanged_Invalid_Should_Pass()
        {
            // Arrange
            var entry = (Entry)page.FindByName("DescValue");

            entry.Text = null;

            var textChanged = new TextChangedEventArgs(entry.Text, null);

            // Act
            page.Desc_TextChanged(null, textChanged);

            // Reset

            // Assert
            Assert.IsTrue(true);

        }

        /// <summary>
        /// Tests if Class_Changed has a null picker entry
        /// </summary>
        [Test]
        public void CharacterCreatePage_Class_Changed_Invalid_Should_Pass()
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

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void CharacterCreatePage_Save_Clicked_Error_Message_IsVisible_False_Should_Pass()
        {
            // Arrange
            var name = (Entry)page.FindByName("NameValue");

            var desc = (Entry)page.FindByName("DescValue");

            var job = (Picker)page.FindByName("ClassPicker");

            name.Text = "test";

            desc.Text = "test";

            job.SelectedItem = CharacterJobEnum.Defender;

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void CharacterCreatePage_Save_Clicked_Error_Message_IsVisible_True_Should_Pass()
        {
            // Arrange
            var name = (Entry)page.FindByName("NameValue");

            var desc = (Entry)page.FindByName("DescValue");

            var job = (Picker)page.FindByName("ClassPicker");

            name.Text = null;

            desc.Text = null;

            job.SelectedItem = null;

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Tests if Level_Changed has a valid picker entry
        /// </summary>
        [Test]
        public void CharacterCreatePage_Level_Changed_Valid_Should_Pass()
        {
            // Arrange
            var selectedClass = (Picker)page.FindByName("LevelPicker");

            selectedClass.SelectedIndex = 20;

            // Act
            page.Class_Changed(selectedClass, null);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }
    }
}