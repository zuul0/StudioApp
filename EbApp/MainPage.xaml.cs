using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EbApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public void ScheduleButton_Clicked(object sender, EventArgs e)
        {
            // Обработчик события нажатия на кнопку "Расписание"
            // Реализация вашей логики для открытия расписания
        }

        private void ContactButton_Clicked(object sender, EventArgs e)
        {
            // Обработчик события нажатия на кнопку "Звонок/Написать"
            // Реализация вашей логики для звонка или отправки сообщения
        }

        private void AllTrainings_Clicked(object sender, EventArgs e)
        {
            // Обработчик события нажатия на ссылку "Все тренировки"
            // Реализация вашей логики для открытия всех тренировок
        }
    }
}
