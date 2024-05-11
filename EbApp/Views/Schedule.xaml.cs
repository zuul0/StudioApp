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
    public partial class Schedule : ContentPage
    {
        public Schedule()
        {
            InitializeComponent();
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            var appointment1 = new Appointment
            {
                DateClass = new DateTime(2024, 5, 15),
                TimeClass = new TimeSpan(10, 0, 0),
                NumOfSeats = 20,
                TrainerId = 1 
            };
            App.Database.AddAppointment(appointment1);

            var appointment2 = new Appointment
            {
                DateClass = new DateTime(2024, 5, 16),
                TimeClass = new TimeSpan(14, 30, 0),
                NumOfSeats = 15,
                TrainerId = 2 
            };
            App.Database.AddAppointment(appointment2);

            var appointments = App.Database.GetAppointments();

            appointmentListView.ItemsSource = appointments;

        }



        // Метод для получения направления тренера
        private string GetTrainerDirection(int trainerId)
        {
            var trainer = App.Database.GetTrainer(trainerId);
            return trainer.Direction;
        }

       

        private void appointmentListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            Appointment selectedAppointment = e.SelectedItem as Appointment;

            //показать дополнительную информацию о нем

            appointmentListView.SelectedItem = null;
        }

    }
}