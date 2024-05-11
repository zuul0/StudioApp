using EbApp.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EbApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {   
        public AppShell()
        {
            InitializeComponent(); 
            
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(TrainersList), typeof(TrainersList));
            Routing.RegisterRoute(nameof(Schedule), typeof(Schedule));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        }

    }
}
