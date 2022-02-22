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
        public GenericViewModel<CharacterModel> ViewModel { get; set; }

        public ItemSelectionPage(GenericViewModel<CharacterModel> data)
        {
            InitializeComponent();
            ViewModel = this.ViewModel = data;
        }

    }
}