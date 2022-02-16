using Game.Models;
using Game.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Battle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BattleCharacterItemsUpdatePage : ContentPage
    {
        //Hold a copy of data
        public CharacterModel DataCopy;

        public GenericViewModel<CharacterModel> ViewModel { get; set; }

        // Empty Constructor for UTs
        public BattleCharacterItemsUpdatePage(bool UnitTest) { }

        // Hold the current location selected
        public ItemLocationEnum PopupLocationEnum = ItemLocationEnum.Unknown;

    

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public BattleCharacterItemsUpdatePage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = data;
            this.ViewModel.Title = "Update " + data.Title;

            //Copy of Character to restore for cancel
            DataCopy = new CharacterModel(data.Data);

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

            //ManageHealth();
            AddItemsToDisplay();

            return true;
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

                MessagingCenter.Send(this, "Update", ViewModel.Data);

            await Navigation.PushAsync(new CharacterReadPage(new GenericViewModel<CharacterModel>(ViewModel.Data)));
        }

        /// <summary>
        /// Cancel the Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Cancel_Clicked(object sender, EventArgs e)
        {
            // Use the copy
            ViewModel.Data.Update(DataCopy);

            _ = await Navigation.PopModalAsync();
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
        /// Show the Items the Character has
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
        /// <param name="location"></param>
        /// <returns></returns>
        public StackLayout GetItemToDisplay(ItemLocationEnum location)
        {
            // Get the Item, if it exist show the info
            // If it does not exist, show a Plus Icon for the location

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
        /// The row selected from the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
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
    }
}