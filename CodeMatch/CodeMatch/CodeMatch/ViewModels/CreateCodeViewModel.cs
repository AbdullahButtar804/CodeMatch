using Android.Content;
using Android.Net.Wifi;
using Android.Net;
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

namespace CodeMatch.ViewModels
{
    public class CreateCodeViewModel : INotifyPropertyChanged
    {
        #region private Properties
        private string code="3Z4e";
        private string networkName;
        private string name="Abdullah";
        INavigation _navigation;
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
        public string Name
        {
            get
            {
                return name;
            }
            set
            {

                name = value;
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

        [Obsolete]
        public CreateCodeViewModel(INavigation naviagtion)
        {
            _navigation = naviagtion;
            GoToNextPageCommand = new Command(GotoNext);
            OnInitialize();
            
            
        }
        #endregion


        #region Commands
        public Command GoToNextPageCommand { get; set; }
        #endregion

        #region Methods
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
        public async void GotoNext()
        {
            if(!string.IsNullOrEmpty(Code)&&!string.IsNullOrEmpty(NetworkName))
            {

                DatabaseHelper.InsertData(Code, NetworkName,Name);
                await _navigation.PushAsync(new VerfyCodePage());
            }
           
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
