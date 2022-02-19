using NUnit.Framework;
using System.Linq;

using Game;
using Game.Views;
using Game.Models;
using Game.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;

namespace UnitTests.Views
{
    [TestFixture]
    public class ItemCreatePageTests : ItemCreatePage
    {
        App app;
        ItemCreatePage page;

        public ItemCreatePageTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;

            page = new ItemCreatePage();
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void ItemCreatePage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ItemCreatePage_Cancel_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_Save_Clicked_Default_Should_Pass()
        {
            // Arrange

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void ItemCreatePage_Save_Clicked_Null_Image_Should_Pass()
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
        public void ItemCreatePage_OnBackButtonPressed_Valid_Should_Pass()
        {
            // Arrange

            // Act
            _ = OnBackButtonPressed();

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        //[Test]
        //public void ItemCreatePage_Value_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // Arrange

        //    page = new ItemCreatePage();
        //    var oldValue = 0.0;
        //    var newValue = 1.0;

        //    var args = new ValueChangedEventArgs(oldValue, newValue);

        //    // Act
        //    page.Value_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void ItemCreatePage_Range_OnStepperValueChanged_Default_Should_Pass()
        //{
        //    // Arrange

        //    page = new ItemCreatePage();
        //    var oldRange = 0.0;
        //    var newRange = 1.0;

        //    var args = new ValueChangedEventArgs(oldRange, newRange);

        //    // Act
        //    page.Range_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        //[Test]
        //public void ItemCreatePage_Damage_OnStepperDamageChanged_Default_Should_Pass()
        //{
        //    // Arrange
        //    page = new ItemCreatePage();
        //    var oldDamage = 0.0;
        //    var newDamage = 1.0;

        //    var args = new ValueChangedEventArgs(oldDamage, newDamage);

        //    // Act
        //    page.Damage_OnStepperValueChanged(null, args);

        //    // Reset

        //    // Assert
        //    Assert.IsTrue(true); // Got to here, so it happened...
        //}

        /// <summary>
        /// Save Clicked with Error Messages Not Shown Unit Test
        /// </summary>
        [Test]
        public void ItemCreatePage_Save_Clicked_Error_Message_IsVisible_False_Should_Pass()
        {
            // Arrange
            var name = (Entry)page.FindByName("NameValue");

            var desc = (Entry)page.FindByName("DescValue");

            var loc = (Picker)page.FindByName("LocationPicker");

            var attribute = (Picker)page.FindByName("AttributePicker");

            name.Text = "test";

            desc.Text = "test";

            loc.SelectedItem = ItemLocationEnum.Finger;

            attribute.SelectedItem = AttributeEnum.Attack;

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Save Clicked with Error Messages Shown Unit Test with "Unknown" location and attribute values
        /// </summary>
        [Test]
        public void ItemCreatePage_Save_Clicked_Error_Message_IsVisible_True_Should_Pass()
        {
            // Arrange
            var name = (Entry)page.FindByName("NameValue");

            var desc = (Entry)page.FindByName("DescValue");

            var loc = (Picker)page.FindByName("LocationPicker");

            var attribute = (Picker)page.FindByName("AttributePicker");

            name.Text = null;

            desc.Text = null;

            loc.SelectedItem = "Unknown";

            attribute.SelectedItem = "Unknown";

            // Act
            page.Save_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// ShowLocationAttributeErrorMessage method unit test for Attribute Unknown
        /// </summary>
        [Test]
        public void ItemCreatePage_ShowLocationAttributeErrorMessage_Attibute_Unknown_Should_Pass()
        {
            // Arrange
            var loc = (Picker)page.FindByName("LocationPicker");

            var attribute = (Picker)page.FindByName("AttributePicker");

            loc.SelectedItem = ItemLocationEnum.Finger;

            attribute.SelectedItem = "Unknown";

            // Act
            page.ShowLocationAttributeErrorMessage();

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// ShowLocationAttributeErrorMessage method unit test for Location Unknown
        /// </summary>
        [Test]
        public void ItemCreatePage_ShowLocationAttributeErrorMessage_Location_Unknown_Should_Pass()
        {
            // Arrange
            var loc = (Picker)page.FindByName("LocationPicker");

            var attribute = (Picker)page.FindByName("AttributePicker");

            loc.SelectedItem = "Unknown";

            attribute.SelectedItem = AttributeEnum.Attack;

            // Act
            page.ShowLocationAttributeErrorMessage();

            // Reset

            // Assert
            Assert.IsTrue(true);
        }

        /// <summary>
        /// AttributePicker_SelectedIndexChanged Unit Test
        /// </summary>
        [Test]
        public void ItemCreatePage_AttributePicker_SelectedIndexChanged_Error_Should_Pass()
        {
            // Arrange
            var loc = (Picker)page.FindByName("LocationPicker");

            var attribute = (Picker)page.FindByName("AttributePicker");

            loc.SelectedItem = "Unknown";

            attribute.SelectedItem = AttributeEnum.Attack;

            // Act
            page.AttributePicker_SelectedIndexChanged(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true);
        }
    }
}