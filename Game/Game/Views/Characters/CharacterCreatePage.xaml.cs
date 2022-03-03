using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.GameRules;
using Game.Models;
using Game.ViewModels;

namespace Game.Views
{
    /// <summary>
    /// Create Character
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    public partial class CharacterCreatePage : ContentPage
    {
        // The Character to create
        public GenericViewModel<CharacterModel> ViewModel { get; set; }
        
        // Hold the current location selected
        public ItemLocationEnum PopupLocationEnum = ItemLocationEnum.Unknown;


        // Empty Constructor for UTs
        public CharacterCreatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public CharacterCreatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            data.Data = new CharacterModel();
            this.ViewModel = data;

            this.ViewModel.Title = "Create";
            NameErrorMessage.IsVisible = false;
            DescErrorMessage.IsVisible = false;            
            ClassErrorMessage.IsVisible = false;

            // Load the values for the Level into the Picker
            for (var i = 1; i <= LevelTableHelper.MaxLevel; i++)
            {
                LevelPicker.Items.Add(i.ToString());
            }

            this.ViewModel.Data.Level = 1;
            LevelPicker.SelectedIndex = ViewModel.Data.Level - 1;

            // Load the values for the Class into the Picker
            ClassPicker.Items.Add(CharacterJobEnum.Defender.ToMessage());
            ClassPicker.Items.Add(CharacterJobEnum.Striker.ToMessage());
            ClassPicker.Items.Add(CharacterJobEnum.Support.ToMessage());

            _ = UpdatePageBindingContext();
        }

        /// <summary>
        /// Redo the Binding to cause a refresh
        /// </summary>
        /// <returns></returns>
        public bool UpdatePageBindingContext()
        {
            // Temp store off the Level
            var level = this.ViewModel.Data.Level;

            // Clear the Binding and reset it
            BindingContext = null;
            BindingContext = this.ViewModel;

            // This resets the Picker to -1 index, need to reset it back
            ViewModel.Data.Level = level;
            LevelPicker.SelectedIndex = ViewModel.Data.Level - 1;

            ManageHealth();
            AddItemsToDisplay();
            return true;
        }

        /// <summary>
        /// Randomize Character Values and Items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RollDice_Clicked(object sender, EventArgs e)
        {
            _ = RandomizeCharacter();
            return;
        }

        /// <summary>
        /// 
        /// Randomize the Character
        /// Keep the Level the Same
        /// 
        /// </summary>
        /// <returns></returns>
        public bool RandomizeCharacter()
        {
            var levelIndex = LevelPicker.SelectedIndex;

            // Need to change the Level picker to allow for the MaxHealth to be triggered
            LevelPicker.SelectedIndex = 0;
            LevelPicker.SelectedIndex = levelIndex;

            ViewModel.Data.Level = levelIndex + 1;

            ManageHealth();

            // Randomize Name
            ViewModel.Data.Name = RandomPlayerHelper.GetCharacterName();
            ViewModel.Data.Description = RandomPlayerHelper.GetCharacterDescription();

            // Randomize the Attributes
            ViewModel.Data.Attack = RandomPlayerHelper.GetAbilityValue();
            ViewModel.Data.Speed = RandomPlayerHelper.GetAbilityValue();
            ViewModel.Data.Defense = RandomPlayerHelper.GetAbilityValue();

            // Randomize an Item for Location
            ViewModel.Data.Head = RandomPlayerHelper.GetItem(ItemLocationEnum.Head);
            ViewModel.Data.Necklass = RandomPlayerHelper.GetItem(ItemLocationEnum.Necklass);
            ViewModel.Data.PrimaryHand = RandomPlayerHelper.GetItem(ItemLocationEnum.PrimaryHand);
            ViewModel.Data.OffHand = RandomPlayerHelper.GetItem(ItemLocationEnum.OffHand);
            ViewModel.Data.RightFinger = RandomPlayerHelper.GetItem(ItemLocationEnum.Finger);
            ViewModel.Data.LeftFinger = RandomPlayerHelper.GetItem(ItemLocationEnum.Finger);
            ViewModel.Data.Feet = RandomPlayerHelper.GetItem(ItemLocationEnum.Feet);

            ViewModel.Data.MaxHealth = RandomPlayerHelper.GetHealth(ViewModel.Data.Level);

            ViewModel.Data.ImageURI = RandomPlayerHelper.GetCharacterImage();

            _ = UpdatePageBindingContext();

            return true;
        }

        /// <summary>
        /// The Level selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Level_Changed(object sender, EventArgs args)
        {
            // Only change if different
            if (LevelPicker.SelectedIndex == -1)
            {
                return;
            }

            if (ViewModel.Data.Level == LevelPicker.SelectedIndex + 1)
            {
                return;
            }

            // Change the Level
            ViewModel.Data.Level = LevelPicker.SelectedIndex + 1;
            ManageHealth();      
        }

        /// <summary>
        /// The Level selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Class_Changed(object sender, EventArgs args)
        {
            var selectedClass = ClassPicker.SelectedItem;   
            if(selectedClass != null)
            {
                ClassErrorMessage.IsVisible = false;
            }
            // Convert class based on selected value
            switch (selectedClass)
            {
                case "Defender":
                    ViewModel.Data.Job = CharacterJobEnum.Defender;
                    break;

                case "Striker":
                    ViewModel.Data.Job = CharacterJobEnum.Striker;
                    break;

                case "Support":
                    ViewModel.Data.Job = CharacterJobEnum.Support;
                    break;

                default:
                    break;
            }            
        }

        /// <summary>
        /// Change the Level Picker
        /// </summary>
        public void ManageHealth()
        {
            // Roll for new HP
            ViewModel.Data.MaxHealth = RandomPlayerHelper.GetHealth(ViewModel.Data.Level);

            // Show the Result
            MaxHealthValue.Text = ViewModel.Data.MaxHealth.ToString();
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = new CharacterModel().ImageURI;
            }

            if (ClassPicker.SelectedItem == null)
            {
                ClassErrorMessage.IsVisible = true;
                ClassErrorMessage.Text = "Please select a Class";
            }

            if(!NameErrorMessage.IsVisible && !DescErrorMessage.IsVisible && !ClassErrorMessage.IsVisible)
            {
                MessagingCenter.Send(this, "Create", ViewModel.Data);
                _ = await Navigation.PopModalAsync();
            }   
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            _ = await Navigation.PopModalAsync();
        }

        /// <summary>
        /// On change event of Attack stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Attack_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            AttackValue.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// On change event of Defense stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Defense_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            DefenseValue.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// On change event of Speed stepper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Speed_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            SpeedValue.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0019:Use pattern matching", Justification = "<Pending>")]
        public void OnPopupItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            ItemModel data = args.SelectedItem as ItemModel;
            if (data == null)
            {
                return;
            }

            _ = ViewModel.Data.AddItem(PopupLocationEnum, data.Id);

            AddItemsToDisplay();

            ClosePopup();
        }

        /// <summary>
        /// Show the Popup for Selecting Items
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool ShowPopup(ItemLocationEnum location)
        {
            PopupItemSelector.IsVisible = true;

            PopupLocationLabel.Text = "Items for :";
            PopupLocationValue.Text = location.ToMessage();

            // Make a fake item for None
            var NoneItem = new ItemModel
            {
                Id = null, // will use null to clear the item
                Guid = "None", // how to find this item amoung all of them
                ImageURI = "icon_cancel.png",
                Name = "None",
                Description = "None"
            };

            List<ItemModel> itemList = new List<ItemModel>
            {
                NoneItem
            };

            // Add the rest of the items to the list
            itemList.AddRange(ItemIndexViewModel.Instance.GetLocationItems(location));

            // Populate the list with the items
            PopupLocationItemListView.ItemsSource = itemList;

            // Remember the location for this popup
            PopupLocationEnum = location;

            return true;
        }

        /// <summary>
        /// Item Location change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Location_Changed(object sender, EventArgs e)
        {
            // Make a fake item for None
            var NoneItem = new ItemModel
            {
                Id = null, // to clear the item
                Guid = "None", // how to find this item amoung all of them
                ImageURI = "icon_cancel.png",
                Name = "None",
                Description = "None"
            };

            List<ItemModel> itemList = new List<ItemModel>
            {
                NoneItem
            };
        }

        /// <summary>
        /// When the user clicks the close in the Popup
        /// hide the view
        /// show the scroll view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ClosePopup_Clicked(object sender, EventArgs e)
        {
            ClosePopup();
        }

        /// <summary>
        /// Close the popup
        /// </summary>
        public void ClosePopup()
        {
            PopupItemSelector.IsVisible = false;
        }

        /// <summary>
        /// Display Items of the Character
        /// </summary>
        public void AddItemsToDisplay()
        {

            var FlexList = ItemBox.Children.ToList();
            foreach (var data in FlexList)
            {
                _ = ItemBox.Children.Remove(data);
            }

            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.Head));
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.Necklass));
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.PrimaryHand));
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.OffHand));
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.RightFinger));
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.LeftFinger));
            ItemBox.Children.Add(GetItemToDisplay(ItemLocationEnum.Feet));           
        }

        /// <summary>
        /// Look up the Item to Display
        /// </summary>
        /// <param name="location">The Location on the Character being selected</param>
        /// <returns>Displays popup view with Item Detail</returns>
        public StackLayout GetItemToDisplay(ItemLocationEnum location)
        {
            // Defualt Image is the Plus
            var ImageSource = "icon_add.png";

            var data = ViewModel.Data.GetItemByLocation(location);
            if (data == null)
            {
                data = new ItemModel { Location = location, ImageURI = ImageSource };
            }

            // Hookup the Image Button to show the Item picture
            var ItemButton = new ImageButton
            {
                Style = (Style)Application.Current.Resources["ImageMediumStyle"],
                Source = data.ImageURI
            };

            // Add a event to the user can click the item and see more
            ItemButton.Clicked += (sender, args) => ShowPopup(location);
            
            // Add the Display Text for the item
            var ItemLabel = new Label
            {
                Text = location.ToMessage(),
                Style = (Style)Application.Current.Resources["ValueStyleMicro"],
                HorizontalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            // Put the Image Button and Text inside a layout
            var ItemStack = new StackLayout
            {
                Padding = 3,
                Style = (Style)Application.Current.Resources["ItemImageLabelBox"],
                HorizontalOptions = LayoutOptions.Center,
                Children = {
                    ItemButton,
                    ItemLabel
                },
            };

            return ItemStack;
        }

        /// <summary>
        /// Name change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameErrorMessage.IsVisible = false;
            if (string.IsNullOrEmpty(NameValue.Text))
            {
                NameErrorMessage.IsVisible = true;
            }
        }

        /// <summary>
        /// Description change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Desc_TextChanged(object sender, TextChangedEventArgs e)
        {
            DescErrorMessage.IsVisible = false;
            if (string.IsNullOrEmpty(DescValue.Text))
            {
                DescErrorMessage.IsVisible = true;
            }
        }      
    }
}