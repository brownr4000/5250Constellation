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
        // Empty Constructor for UTs
        bool UnitTestSetting;
        public BattleEntryPage(bool UnitTest) { UnitTestSetting = UnitTest; }

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

        /// <summary>
        /// Navigate to pick characters page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ProtectButton_Clicked(object sender, EventArgs e) {
            await Navigation.PushAsync(new PickCharactersPage());
        }
    }
}