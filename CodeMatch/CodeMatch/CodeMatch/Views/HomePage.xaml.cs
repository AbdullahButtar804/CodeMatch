using CodeMatch.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeMatch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        HomePageViewMode viewMode;
        public HomePage()
        {
            InitializeComponent();
            BindingContext = viewMode = new HomePageViewMode(Navigation);
        }
    }
}