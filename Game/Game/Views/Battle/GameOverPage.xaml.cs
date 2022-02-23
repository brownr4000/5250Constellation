﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Game.Views.Battle
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GameOverPage : ContentPage
    {
        public GameOverPage()
        {
            InitializeComponent();
        }

        public async void ViewResult_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScoreIndexPage());
        }
    }
}