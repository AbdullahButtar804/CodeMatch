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
    public class HomePageViewMode : INotifyPropertyChanged
    {
        #region private Properties
        private string name;
        INavigation _navigation;
        #endregion

        #region Public Properties
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
      
        

        #endregion

        #region Constructor
        public HomePageViewMode(INavigation naviagtion)
        {

            _navigation = naviagtion;
            GoBackCommand = new Command(GoBack);
            OnInitialize();
        }
        #endregion


        #region Commands
        public Command GoBackCommand { get; set; }
        
        #endregion

        #region Methods
        public async void GoBack()
        {
            await _navigation.PopAsync();
            
        }

        [Obsolete]
        public void OnInitialize()
        {
            Name = DatabaseHelper.GetStoredUserName();
        }

       
        
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
