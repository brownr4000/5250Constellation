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
    public partial class ItemSelectionPage : ContentPage
    {
        // The item to create
        public GenericViewModel<ItemModel> ViewModel = new GenericViewModel<ItemModel>();

        public List<ItemModel> ItemList { get; }

        // Item index variable, to load first item
        public int itemImageIndex = 0;
        public ItemSelectionPage(List<ItemModel> itemList)
        {
            InitializeComponent();

            this.ViewModel.Data = new ItemModel();

            ItemList = itemList;

            // Load the first image in the list when the Create page is opened
            this.ViewModel.Data.Name = ItemList[itemImageIndex].Name;
            this.ViewModel.Data.ImageURI = ItemList[itemImageIndex].NewItemImageURI;


        }

        public bool UpdatePageBindingContext()
        {
            // Clear the Binding and reset it
            BindingContext = null;
            BindingContext = this.ViewModel;

            return true;
        }

        public void LeftImageButton_Clicked(object sender, EventArgs e)
        {
            int imageCount = ItemList.Count;

            // check if we are at the first photo and move to last photo when clicked
            if (itemImageIndex == 0)
            {
                itemImageIndex = imageCount - 1;
            }

            // Move to the previous photo in the list
            if (itemImageIndex > 0)
            {
                itemImageIndex--;
            }

            // Update the image
            this.ViewModel.Data.Name = ItemList[itemImageIndex].Name;
            this.ViewModel.Data.ImageURI = ItemList[itemImageIndex].NewItemImageURI;
            itemImage.Source = this.ViewModel.Data.ImageURI;
            itemName.Text = this.ViewModel.Data.Name;
        }

        public void RightImageButton_Clicked(object sender, EventArgs e)
        {
            int imageCount = ItemList.Count;

            // check if we are at the last photo and move to first photo when clicked
            if (itemImageIndex == imageCount - 1)
            {
                itemImageIndex = 0;
            }

            // Move to the next photo in the list
            else if (itemImageIndex < imageCount - 1)
            {
                itemImageIndex++;
            }

            // Update the image
            this.ViewModel.Data.Name = ItemList[itemImageIndex].Name;
            this.ViewModel.Data.ImageURI = ItemList[itemImageIndex].NewItemImageURI;
            itemImage.Source = this.ViewModel.Data.ImageURI;
            itemName.Text = this.ViewModel.Data.Name;
        }

    }
}