using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EbApp.Models
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrainerDetailPage : ContentPage
    {
        public TrainerDetailPage(Trainer trainer)
        {
            InitializeComponent();

          
                Title = "Trainer Details";

                // Создание макета для отображения подробной информации о тренере
                var stackLayout = new StackLayout();

                var nameLabel = new Label { Text = $"{trainer.FirstName} {trainer.LastName}", FontAttributes = FontAttributes.Bold };
                var directionLabel = new Label { Text = $"Direction: {trainer.Direction}" };
                var middleNameLabel = new Label { Text = $"Middle Name: {trainer.MiddleName}" };

                stackLayout.Children.Add(nameLabel);
                stackLayout.Children.Add(directionLabel);
                stackLayout.Children.Add(middleNameLabel);

                Content = stackLayout;
            }
        }
    }
