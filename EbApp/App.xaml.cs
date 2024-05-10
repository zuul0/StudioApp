using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System;
using System.IO;
using EbApp.Models;

namespace EbApp
{
    public partial class App : Application
    {
       public const string DATABASE_NAME = "PC.db";
        public static Reposit database;
        public static Reposit Database
        {
            get
            {
                if (database == null)
                {
                    database = new Reposit(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }
        public static int CurrentClientId { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
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
