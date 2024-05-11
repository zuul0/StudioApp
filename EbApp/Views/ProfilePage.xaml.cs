using EbApp.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EbApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {

        public Client currentUser;
        public ProfilePage()
        {
            DisplayAlert("Неправильный email", "Произошла ошибка", "OK");
            InitializeComponent();

        }
      
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsUserAuthenticated())
            {
                DisplayUserData();
            }
            else
            {
                NavigateToAuthenticationPage();
            }
        }
        private bool IsUserAuthenticated()
        {
            //if (currentClient != null)
            //return true;
            //else
            //    return false;
            if (App.Current.Properties.ContainsKey("currentUser"))
            {
                string userJson = App.Current.Properties["currentUser"].ToString();
                currentUser = JsonConvert.DeserializeObject<Client>(userJson);
                return true; 
            }
            else return false;
        }

        private void DisplayUserData()
        {
            BindingContext = currentUser; 
        }

        private void NavigateToAuthenticationPage()
        {
            Navigation.PushAsync(new Registration());
        }

    }
    
}
