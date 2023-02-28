using Android.Content;
using Android.Net;
using Android.Net.Wifi;
using CodeMatch.Helpers;
using CodeMatch.Models;
using CodeMatch.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace CodeMatch.ViewModels
{
    public class VerifyCodeViewModel : INotifyPropertyChanged
    {
        #region private Properties
        private string code;
        INavigation _navigation;
    
        private string networkName;
        #endregion


        #region Public Properties
        public string Code 
        { 
            get
            { 
                return code; 
            } 
            set 
            {
                
                code = value; 
            } 
        } 
        public string NetworkName 
        { 
            get
            { 
                return networkName; 
            } 
            set 
            {

                networkName = value; 
            } 
        }
        
        

        #endregion


        #region Constructor
        public VerifyCodeViewModel(INavigation naviagtion)
        {

            _navigation = naviagtion;
            OnInitialize();
            GoBackCommand = new Command(GoBack);
            GoToNextPageCommand = new Command(GotoNext);
        }
        #endregion


        #region Commands
        public Command GoBackCommand { get; set; }
        public Command GoToNextPageCommand { get; set; }
        #endregion

        #region Methods
        public async void GoBack()
        {
            await _navigation.PopAsync();
            
        }

        [Obsolete]
        public void OnInitialize()
        {
            var connectivityManager = (ConnectivityManager)Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
            NetworkInfo networkInfo = connectivityManager.GetNetworkInfo(ConnectivityType.Wifi);
            if (networkInfo.IsConnected)
            {
                WifiManager wifiManager = (WifiManager)Android.App.Application.Context.GetSystemService(Context.WifiService);
                WifiInfo wifiInfo = wifiManager.ConnectionInfo;
                string name = networkInfo.ExtraInfo;
                NetworkName = "\"" + wifiInfo.SSID + "\"";
            }
            
        }

        [Obsolete]
        public async void GotoNext()
        {
            var connectivityManager = (ConnectivityManager)Android.App.Application.Context.GetSystemService(Context.ConnectivityService);
            NetworkInfo networkInfo = connectivityManager.GetNetworkInfo(ConnectivityType.Wifi);
            if (networkInfo.IsConnected)
            {
                var code = DatabaseHelper.GetStoredCode();
                var _NetworkInfo = DatabaseHelper.GetStoredNetworkName();

                if (!string.IsNullOrEmpty(Code) && _NetworkInfo == NetworkName && code == Code)
                {
                    
                    await _navigation.PushAsync(new HomePage());
                }
            }
            else
               await Application.Current.MainPage.DisplayAlert("Sorry", "You don't have active internet connection", "Okay");
            

        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
