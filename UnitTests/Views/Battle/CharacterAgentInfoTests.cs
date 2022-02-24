using NUnit.Framework;
using System.Linq;

using Game;
using Game.Views;
using Game.ViewModels;
using Game.Models;

using Xamarin.Forms;
using Xamarin.Forms.Mocks;
using System.Threading.Tasks;

namespace UnitTests.Views
{
    [TestFixture]
    public class CharacterAgentInfoTests : CharacterAgentInfoPage
    {
        App app;
        CharacterAgentInfoPage page;

        public CharacterAgentInfoTests() : base(true) { }

        [SetUp]
        public void Setup()
        {
            // Initilize Xamarin Forms
            MockForms.Init();

            //This is your App.xaml and App.xaml.cs, which can have resources, etc.
            app = new App();
            Application.Current = app;


            var characterModel = new GenericViewModel<CharacterModel>(new CharacterModel());
            var characterIndexViewModel = CharacterIndexViewModel.Instance;

            //page = new CharacterAgentInfoPage(new GenericViewModel<CharacterModel>(new CharacterModel()), new CharacterIndexViewModel());
            page = new CharacterAgentInfoPage(characterModel, characterIndexViewModel);
        }

        [TearDown]
        public void TearDown()
        {
            Application.Current = null;
        }

        [Test]
        public void CharacterAgentInfoPage_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = page;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CharacterAgentInfoPage_CancelButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.Cancel_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterAgentInfoPage_SelectButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.Select_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterAgentInfoPage_LeftImageButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.LeftImageButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterAgentInfoPage_RightImageButton_Clicked_Default_Should_Pass()
        {
            // Arrange
            // Act
            page.RightImageButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }

        [Test]
        public void CharacterAgentInfoPage_RightImageButton_LastImage_Clicked_Default_Should_Pass()
        {
            // Arrange
           

            int imageCount = AllCharactersList.Count;

            int characterImageIndex = imageCount - 1;

            // Act
            page.RightImageButton_Clicked(null, null);

            // Reset

            // Assert
            Assert.IsTrue(true); // Got to here, so it happened...
        }
    }
}