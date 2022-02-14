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
    public partial class BattleEntryPage : ContentPage
    {
        public BattleEntryPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cancel and close this page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public async void CancelButton_Clicked(object sender, EventArgs e ) {
            _= await Navigation.PopAsync();
        }

        public async void ProtectButton_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new PickCharactersPage());
        }
    }
}