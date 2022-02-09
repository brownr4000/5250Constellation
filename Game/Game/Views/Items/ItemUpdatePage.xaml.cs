using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Game.ViewModels;
using Game.Models;
using Game.GameRules;

namespace Game.Views
{
    /// <summary>
    /// Item Update Page
    /// </summary>
    [DesignTimeVisible(false)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemUpdatePage : ContentPage
    {
        // View Model for Item
        public readonly GenericViewModel<ItemModel> ViewModel;

        //Hold a copy of data
        public ItemModel DataCopy;

        // Empty Constructor for Tests
        public ItemUpdatePage(bool UnitTest) { }

        /// <summary>
        /// Constructor that takes and existing data item
        /// </summary>
        public ItemUpdatePage(GenericViewModel<ItemModel> data)
        {
            InitializeComponent();

            //Copy of Character to restore for cancel
            DataCopy = new ItemModel(data.Data);

            BindingContext = this.ViewModel = data;

            this.ViewModel.Title = "Update " + data.Title;

            //Need to make the SelectedItem a string, so it can select the correct item.
            LocationPicker.SelectedItem = data.Data.Location.ToMessage();
            AttributePicker.SelectedItem = data.Data.Attribute.ToString();

        }
        
        /// <summary>
        /// Event Handler for Name's Text Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Name_TextChanged(object sender, TextChangedEventArgs e) {
            NameErrorMessage.IsVisible = false;

            if (String.IsNullOrEmpty(NameValue.Text)) {
                NameErrorMessage.IsVisible = true;
            }
        }

        /// <summary>
        /// Event Handler for Description 's Text Changed
        /// </summary>
        /// <param name="sendder"></param>
        /// <param name="e"></param>
        public void Description_TextChanged(object sendder, TextChangedEventArgs e) {
            DescriptionErrorMessage.IsVisible = false;

            if (String.IsNullOrEmpty(DescriptionValue.Text)) {
                DescriptionErrorMessage.IsVisible = true;
            }
        }

        /// <summary>
        /// Save calls to Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            
            // If the image in the data box is empty, use the default one..
            if (string.IsNullOrEmpty(ViewModel.Data.ImageURI))
            {
                ViewModel.Data.ImageURI = Services.ItemService.DefaultImageURI;
            }

            if (!NameErrorMessage.IsVisible && !DescriptionErrorMessage.IsVisible)
            {
                MessagingCenter.Send(this, "Update", ViewModel.Data);
                _ = await Navigation.PopModalAsync();
            }

        }

        /// <summary>
        /// Cancel and close this page
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
        /// Catch the change to the Stepper for Range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Range_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            RangeValue.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Catch the change to the stepper for Value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Value_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            ValueValue.Text = string.Format("{0}", e.NewValue);
        }

        /// <summary>
        /// Catch the change to the stepper for Damage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Damage_OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            DamageValue.Text = string.Format("{0}", e.NewValue);
        }     
    }
}