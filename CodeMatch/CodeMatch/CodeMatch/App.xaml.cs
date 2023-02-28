using CodeMatch.Helpers;
using CodeMatch.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodeMatch
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DatabaseHelper.CreateDatabase();
            MainPage = new NavigationPage(new CreateCodePage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
