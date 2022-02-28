using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using Game.Models;
using Game.ViewModels;
using System.Linq;
using Game.Views.Battle;

namespace Game.Views
{
    /// <summary>
    /// Selecting Characters for the Game
    /// 
    /// TODO: Team
    /// Mike's game allows duplicate characters in a party (6 Mikes can all fight)
    /// If you do not allow duplicates, change the code below
    /// Instead of using the database list directly make a copy of it in the viewmodel
    /// Then have on select of the database remove the character from that list and add to the part list
    /// Have select from the party list remove it from the party list and add it to the database list
    ///
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0019:Use pattern matching", Justification = "<Pending>")]
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CharacterAgentInfoPage : ContentPage
    {
        private GenericViewModel<CharacterModel> ViewModel;

        public List<CharacterModel> AllCharactersList { get; set; }

        // Character index variable, to load first item
        public int characterImageIndex = 0;

        //Hold a copy of data
        public CharacterModel DataCopy;

        //Empty Constructor for UTs
          public CharacterAgentInfoPage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Index Page accepting data
        /// 
        /// Get the CharacterIndexView Model
        /// </summary>
        public CharacterAgentInfoPage(GenericViewModel<CharacterModel> characterData, CharacterIndexViewModel characterViewModel)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = characterData;

            AllCharactersList = new List<CharacterModel>();

            foreach (CharacterModel character in characterViewModel.Dataset)
            {
                AllCharactersList.Add(character);
            }

            //Copy of Character to restore for cancel
            DataCopy = new CharacterModel(characterData.Data);
        }

        /// <summary>
        /// Cancel button clicked goes to index page without selecting  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new PickCharactersPage()));
            _ = await Navigation.PopAsync();
        }

        /// <summary>
        /// Next button clicked selects the character and goes back to item pick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Select_Clicked(object sender, EventArgs e)
        {
            // Check to avoid duplicates to the character list
            if (BattleEngineViewModel.Instance.PartyCharacterList.Count > 0)
            {
                bool isDuplicateCharacter = false;
                foreach (var character in BattleEngineViewModel.Instance.PartyCharacterList)
                {
                    if (character.Id == this.ViewModel.Data.Id)
                    {
                        isDuplicateCharacter = true;                       
                    }
                }
                if (!isDuplicateCharacter)
                {
                    BattleEngineViewModel.Instance.PartyCharacterList.Add(this.ViewModel.Data);
                }
            }

            // First character added to list
            if (BattleEngineViewModel.Instance.PartyCharacterList.Count == 0)
            {
                BattleEngineViewModel.Instance.PartyCharacterList.Add(this.ViewModel.Data);
            }

            await Navigation.PushModalAsync(new NavigationPage(new PickCharactersPage()));
            await Navigation.PopAsync();
        }

        public void LeftImageButton_Clicked(object sender, EventArgs e)
        {
            int imageCount = AllCharactersList.Count;

            // Check if we are at the first photo and move to last photo when clicked
            if (characterImageIndex == 0)
            {
                characterImageIndex = imageCount - 1;
            }

            // Move to the previous photo in the list
            if (characterImageIndex > 0)
            {
                characterImageIndex--;
            }

            // Update the data
            CharacterImage.Source = AllCharactersList[characterImageIndex].ImageURI;
            CharacterNameLabel.Text = AllCharactersList[characterImageIndex].Name;
            AttackProgressBar.Progress = AllCharactersList[characterImageIndex].Attack;
            SpeedProgressBar.Progress = AllCharactersList[characterImageIndex].Speed;
            DefenseProgressBar.Progress = AllCharactersList[characterImageIndex].Defense;
            HealthProgressBar.Progress = AllCharactersList[characterImageIndex].CurrentHealth;
            AttackLabel.Text = AllCharactersList[characterImageIndex].Attack.ToString();
            SpeedLabel.Text = AllCharactersList[characterImageIndex].Speed.ToString();
            DefenseLabel.Text = AllCharactersList[characterImageIndex].Defense.ToString();
            HealthLabel.Text = AllCharactersList[characterImageIndex].CurrentHealth.ToString();

            // Update ViewModel with latest character selected to pass this to pick characters page
            this.ViewModel.Data = AllCharactersList[characterImageIndex];

        }

        public void RightImageButton_Clicked(object sender, EventArgs e)
        {
            int imageCount = AllCharactersList.Count;

            // check if we are at the last photo and move to first photo when clicked
            if (characterImageIndex == imageCount - 1)
            {
                characterImageIndex = 0;
            }

            // Move to the next photo in the list
            else if (characterImageIndex < imageCount - 1)
            {
                characterImageIndex++;
            }

            // Update the data
            CharacterImage.Source = AllCharactersList[characterImageIndex].ImageURI;
            CharacterNameLabel.Text = AllCharactersList[characterImageIndex].Name;
            AttackProgressBar.Progress = AllCharactersList[characterImageIndex].Attack;
            SpeedProgressBar.Progress = AllCharactersList[characterImageIndex].Speed;
            DefenseProgressBar.Progress = AllCharactersList[characterImageIndex].Defense;
            HealthProgressBar.Progress = AllCharactersList[characterImageIndex].CurrentHealth;
            AttackLabel.Text = AllCharactersList[characterImageIndex].Attack.ToString();
            SpeedLabel.Text = AllCharactersList[characterImageIndex].Speed.ToString();
            DefenseLabel.Text = AllCharactersList[characterImageIndex].Defense.ToString();
            HealthLabel.Text = AllCharactersList[characterImageIndex].CurrentHealth.ToString();

            // Update ViewModel with latest character selected to pass this to pick items page
            this.ViewModel.Data = AllCharactersList[characterImageIndex];
        }

    }
}