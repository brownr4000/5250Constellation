using Game.Models;
using Game.ViewModels;

using System;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views
{
    /// <summary>
    /// Create Item
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemCreatePage : ContentPage
    {
        // The item to create
        public GenericViewModel<ItemModel> ViewModel = new GenericViewModel<ItemModel>();

        // Empty Constructor for UTs
        public ItemCreatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor for Create makes a new model
        /// </summary>
        public ItemCreatePage()
        {
            InitializeComponent();

            this.ViewModel.Data = new ItemModel();
            
            BindingContext = this.ViewModel;

            this.ViewModel.Title = "Create";
            
            // Adding Location value to the picker selected item
            LocationPicker.SelectedItem = ViewModel.Data.Location.ToString();
            
            // Adding Attribute value to the picker selected item
            AttributePicker.SelectedItem = ViewModel.Data.Attribute.ToString();
            
            LocationAttributeErrorMessage.IsVisible = false;            
            
            ShowHideRange(false);
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            // New item default image while saving
            ViewModel.Data.ImageURI = Services.ItemService.DefaultNewItemImageURI;

            // Setting Location/Attribute error message with text
            bool isShowLocationAttributeErrorMessage = ShowLocationAttributeErrorMessage();

            if (!NameErrorMessage.IsVisible && !DescErrorMessage.IsVisible && !isShowLocationAttributeErrorMessage)
            {
                MessagingCenter.Send(this, "Create", ViewModel.Data);
                _ = await Navigation.PopModalAsync();
            }
        }

        public bool ShowLocationAttributeErrorMessage()
        {
            bool returnValue = false;
            LocationAttributeErrorMessage.Text = "";

            var locationValue = LocationPicker.SelectedItem.ToString();
            var attributeValue = AttributePicker.SelectedItem.ToString();

            // Setting the error message when Location or Location and Attribute values are unknown 
            if (locationValue == "Unknown")
            {               
                LocationAttributeErrorMessage.Text = attributeValue == "Unknown" ? "Please select a Location and Attribute" : "Please select a Location";
                LocationAttributeErrorMessage.IsVisible = true;
                returnValue = true;                
            }
            
            // Setting error message when only the attribute value is unknown
            if (locationValue != "Unknown" && attributeValue == "Unknown")
            {
                LocationAttributeErrorMessage.Text = "Please select an Attribute";
                LocationAttributeErrorMessage.IsVisible = true;
                returnValue = true;
            }

            LocationAttributeErrorMessage.IsVisible = returnValue;

            return returnValue;            
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
        /// On text change event for Range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RangeValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            double rangeValueinDouble = RangeValue.Text != "" ? double.Parse(RangeValue.Text) : 0;
            ShowHideDamage(rangeValueinDouble);
        }

        /// <summary>
        /// Show or hide Damage based on Range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ShowHideDamage(double value)
        {
            DamageValue.IsVisible = true;
            DamageLabel.IsVisible = true;

            if (value < 1)
            {
                DamageValue.IsVisible = false;
                DamageLabel.IsVisible = false;
                DamageValue.Text = null;
                return;
            }            
        }

        /// <summary>
        /// Show or hide Range on Page load and Location selected
        /// </summary>
        public void ShowHideRange(bool rangeStatus)
        {
            //rangeStatus = true(show) or false(hide)
            RangeLabel.IsVisible = rangeStatus;
            RangeValue.IsVisible = rangeStatus;
        }

        /// <summary>
        /// On text change event for Name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameErrorMessage.IsVisible = false;

            if(string.IsNullOrEmpty(NameValue.Text))
            {
                NameErrorMessage.IsVisible = true;
            }
        }
        
        /// <summary>
        /// On text change event for Brief Description
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

        /// <summary>
        /// On value changed event for Location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocationPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Default Range and Damage values
            RangeValue.Text = "0";
            DamageValue.Text = "0";

            ShowHideRange(false);

            var selectedItem = LocationPicker.SelectedItem;

            LocationAttributeErrorMessage.IsVisible = false;

            if (selectedItem.ToString() == "PrimaryHand")
            {
                ShowHideRange(true);
                RangeValue.Text = "1";
            }
        }

        /// <summary>
        /// On value change event for Attribute
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttributePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            LocationAttributeErrorMessage.IsVisible = false;
        }
    }
}