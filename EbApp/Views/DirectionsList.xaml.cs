using EbApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EbApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DirectionsList : ContentPage
    {
        public DirectionsList()
        {
            InitializeComponent();
            DisplayTrainers();
        }
        private void DisplayTrainers()
        {
            var trainers = App.Database.GetTrainers();
            directionsListview.ItemsSource = trainers;
        }
    }
}