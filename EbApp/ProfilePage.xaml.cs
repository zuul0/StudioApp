using EbApp.Models;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EbApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }
        private Client currentClient;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            CheckAuthorization();
        }

        private void CheckAuthorization()
        {

            
        }

        private void UpdateClientProfile(object sender, EventArgs e)
        {

    }
}
}