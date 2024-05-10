using EbApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EbApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainersList : ContentPage
    {
        public TrainersList()
        {
            InitializeComponent();
            DisplayTrainers();
        }


        private void DisplayTrainers()
        {
            var trainers = App.Database.GetTrainers();
            trainersListView.ItemsSource = trainers;
        }
        private void trainersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            Trainer selectedTrainer = e.SelectedItem as Trainer; // Assuming Trainer is the type of your items

            // Navigate to a new page with detailed information about the selected trainer
            Navigation.PushAsync(new TrainerDetailPage(selectedTrainer));

            trainersListView.SelectedItem = null;
        }
    }
}
