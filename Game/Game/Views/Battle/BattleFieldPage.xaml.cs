using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Game.Views.Battle;
using Game.Models;
using Game.ViewModels;

namespace Game.Views
{
    /// <summary>
    /// The Main Game Page
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
    public partial class BattleFieldPage : ContentPage
    {
        // Empty Constructor for UTs
        bool UnitTestSetting;
        public BattleFieldPage(bool UnitTest) { UnitTestSetting = UnitTest; }

        /// <summary>
        /// Constructor
        /// </summary>
        public BattleFieldPage()
        {
            InitializeComponent();
            BindingContext = BattleEngineViewModel.Instance;
        }

        public void FightButton_Clicked(object sender, EventArgs e)
        {
            // Fight button code
        }

        public void DefenseButton_Clicked(object sender, EventArgs e)
        {
            // Defense button code
        }
    }
}