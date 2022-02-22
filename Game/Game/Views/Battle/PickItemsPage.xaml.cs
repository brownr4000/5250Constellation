using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.ViewModels;
using Game.Models;
using System.Linq;
using System.Collections.Generic;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickItemsPage : ContentPage
    {
        // The Item to create
        public GenericViewModel<CharacterModel> ViewModel { get; set; }

        // Hold the current location selected
        public ItemLocationEnum PopupLocationEnum = ItemLocationEnum.Unknown;

        // Empty Constructor for UTs
        public PickItemsPage(bool UnitTest) { }

        //Hold a copy of data
        public CharacterModel DataCopy;

        /// <summary>
        /// Constructor
        /// </summary>
        public PickItemsPage(GenericViewModel<CharacterModel> data)
        { 

            InitializeComponent();
            BindingContext = this.ViewModel = data;

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

            // Clear the Binding and reset it
            BindingContext = null;
            BindingContext = this.ViewModel;

            AddItemsToDisplay();

            return true;
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

            //// Add a event to the user can click the item and see more
            //ItemButton.Clicked += (sender, args) => ShowPopup(location);

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


        //// <summary>
        /// Cancel button clicked goes to index page without selecting  
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
        /// Next button clicked selects the character and goes back to index page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Protect_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new NewRoundPage());
        }
    }
}