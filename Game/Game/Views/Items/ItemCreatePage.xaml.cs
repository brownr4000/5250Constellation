﻿using Game.Models;
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
            LocationPicker.SelectedItem = ViewModel.Data.Location.ToString();
            AttributePicker.SelectedItem = ViewModel.Data.Attribute.ToString();
            ShowHideDamage(Double.Parse(RangeValue.Text));
        }

        /// <summary>
        /// Save by calling for Create
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Save_Clicked(object sender, EventArgs e)
        {
            // If the image in the data box is empty, use the default one..
            //New item default image while saving
            ViewModel.Data.ImageURI = Services.ItemService.DefaultNewItemImageURI;
            if(!NameErrorMessage.IsVisible && !DescErrorMessage.IsVisible)
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
                return;
            }
        }

        /// <summary>
        /// On text change event for Name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameErrorMessage.IsVisible = false;
            if(String.IsNullOrEmpty(NameValue.Text))
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
            if (String.IsNullOrEmpty(DescValue.Text))
            {
                DescErrorMessage.IsVisible = true;
            }
        }
    }
}