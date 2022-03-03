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
        //// The item to select
        //public GenericViewModel<ItemModel> ViewModel = new GenericViewModel<ItemModel>();

        // Empty Constructor for UTs
        bool UnitTestSetting;
        public ItemSelectionPage(bool UnitTest) { UnitTestSetting = UnitTest; }

        // The character

        //public List<ItemModel> ItemList { get; }

        //// Item index variable, to load first item
        //public int itemImageIndex = 0;

        ////Hold a copy of data
        //public ItemModel DataCopy;

        //public ItemSelectionPage(List<ItemModel> itemList)
        public ItemSelectionPage()
        {
            InitializeComponent();

            //this.ViewModel.Data = new ItemModel();

            ////Copy of Character to restore for cancel
            //DataCopy = this.ViewModel.Data;

            //ItemList = itemList;

            //// Load the first image in the list when the Create page is opened
            //this.ViewModel.Data.Name = ItemList[itemImageIndex].Name;
            //this.ViewModel.Data.ImageURI = ItemList[itemImageIndex].NewItemImageURI;
            //this.ViewModel.Data.Location = ItemList[itemImageIndex].Location;
            //this.ViewModel.Data.Range = ItemList[itemImageIndex].Range;
            //this.ViewModel.Data.Damage = ItemList[itemImageIndex].Damage;
            //this.ViewModel.Data.Attribute = ItemList[itemImageIndex].Attribute;
            //this.ViewModel.Data.Description = ItemList[itemImageIndex].Description;
        }

        //public bool UpdatePageBindingContext()
        //{
        //    // Clear the Binding and reset it
        //    BindingContext = null;
        //    BindingContext = this.ViewModel;

        //    return true;
        //}

        //public void LeftImageButton_Clicked(object sender, EventArgs e)
        //{
        //    int imageCount = ItemList.Count;

        //    // check if we are at the first photo and move to last photo when clicked
        //    if (itemImageIndex == 0)
        //    {
        //        itemImageIndex = imageCount - 1;
        //    }

        //    // Move to the previous photo in the list
        //    if (itemImageIndex > 0)
        //    {
        //        itemImageIndex--;
        //    }

        //    // Update the image
        //    this.ViewModel.Data.Name = ItemList[itemImageIndex].Name;
        //    this.ViewModel.Data.ImageURI = ItemList[itemImageIndex].NewItemImageURI;
        //    itemImage.Source = this.ViewModel.Data.ImageURI;
        //    itemName.Text = this.ViewModel.Data.Name;
        //    LocationLabel.Text = ItemList[itemImageIndex].Location.ToString();
        //    RangeValue.Progress = ItemList[itemImageIndex].Range;
        //    DamageValue.Progress = ItemList[itemImageIndex].Damage;
        //    DamageLabel.Text = ItemList[itemImageIndex].Damage.ToString();
        //    AttributesLabel.Text = ItemList[itemImageIndex].Attribute.ToString();
        //    DescriptionLabel.Text = ItemList[itemImageIndex].Description;
        //}

        //public void RightImageButton_Clicked(object sender, EventArgs e)
        //{
        //    int imageCount = ItemList.Count;

        //    // check if we are at the last photo and move to first photo when clicked
        //    if (itemImageIndex == imageCount - 1)
        //    {
        //        itemImageIndex = 0;
        //    }

        //    // Move to the next photo in the list
        //    else if (itemImageIndex < imageCount - 1)
        //    {
        //        itemImageIndex++;
        //    }

        //    // Update the image
        //    this.ViewModel.Data.Name = ItemList[itemImageIndex].Name;
        //    this.ViewModel.Data.ImageURI = ItemList[itemImageIndex].NewItemImageURI;
        //    itemImage.Source = this.ViewModel.Data.ImageURI;
        //    itemName.Text = this.ViewModel.Data.Name;
        //    LocationLabel.Text = ItemList[itemImageIndex].Location.ToString();
        //    RangeValue.Progress = ItemList[itemImageIndex].Range;
        //    DamageValue.Progress = ItemList[itemImageIndex].Damage;
        //    DamageLabel.Text = ItemList[itemImageIndex].Damage.ToString();
        //    AttributesLabel.Text = ItemList[itemImageIndex].Attribute.ToString();
        //    DescriptionLabel.Text = ItemList[itemImageIndex].Description;
        //}

        ////// <summary>
        ///// Cancel button clicked goes to index page without selecting  
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public async void Delete_Clicked(object sender, EventArgs e)
        //{
        //    // Use the copy
        //    ViewModel.Data.Update(DataCopy);
        //    _ = await Navigation.PopModalAsync();
        //}

        ///// <summary>
        ///// Next button clicked selects the character and goes back to index page
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //public async void Save_Clicked(object sender, EventArgs e)
        //{
        //    MessagingCenter.Send(this, "Update", ViewModel.Data);

        //    _ = await Navigation.PopModalAsync();

        //}

    }
}