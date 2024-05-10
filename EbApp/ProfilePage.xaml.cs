using EbApp.Models;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Mail;
using System.Net;

namespace EbApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private string verificationCode;
        public ProfilePage()
        {
            InitializeComponent();
        }
        private Client currentClient;
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsUserAuthenticated())
            {
                // Пользователь авторизован, отображаем его данные
                DisplayUserData();
            }
            else
            {
                // Переход к процессу авторизации
                NavigateToAuthenticationPage();
            }
        }

        private bool IsEmailValid(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }
        private async void SendEmailButton_Clicked(object sender, EventArgs e)
        {

            string email = EmailEntry.Text.Trim();
            if (!string.IsNullOrWhiteSpace(email) && IsEmailValid(email))
            {
                try
                {
                    Random random = new Random();
                    verificationCode = random.Next(100000, 999999).ToString();

                    MailAddress from = new MailAddress("akmilia@yandex.ru", "Kamila Gayalieva");
                    //MailAddress from = new MailAddress("sofapetrova2@mail.ru", "Kamila Gayalieva");
                    MailAddress to = new MailAddress(email);
                    MailMessage m = new MailMessage(from, to);
                    m.Body = verificationCode;
                    m.Subject = "Код подтверждения";
                    m.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
                    //smtp.Credentials = new NetworkCredential("sofapetrova2@mail.ru", "tuq6cwwAzBrkL3m6sApd");
                    smtp.Credentials = new NetworkCredential("akmilia@yandex.ru", "pykcchsqhgafxpuv");
                    smtp.EnableSsl = true;

                    await smtp.SendMailAsync(m);
                    DisplayAlert("Успешно", "Код отправлен на вашу почту", "OK");
                    CodeEntryLayout.IsVisible = true;
                }
                catch (Exception ex)
                {
                    DisplayAlert("Ошибка", "Упс, что-то пошло не так, попробуйте заново", "OK" + ex.Message);
                }
            }
            else
            {
                DisplayAlert("Неправильный email", "Произошла ошибка", "OK");
            }
        }
        private async void VerifyCodeButton_Clicked(object sender, EventArgs e)
        {
            string enteredCode = CodeEntry.Text;

            if (enteredCode == verificationCode)
            {
                AdditionalInfoLayout.IsVisible = true;
                DisplayAlert("Успешно", "Введенный код верный. ", "OK");

            }
            else
            {
                DisplayAlert("Ошибка", "Введенный код неверный. Попробуйте снова.", "OK");
                CodeEntry.Text = "";
            }
        }

        private bool IsUserAuthenticated()
        {
                       return true;
        }
        private void SaveClientButton_Clicked(object sender, EventArgs e)
        {
            string firstName = FirstNameEntry.Text;
            string lastName = LastNameEntry.Text;
            string email = EmailEntry.Text;

            // Создание нового клиента или обновление существующего
            Client client = new Client
            {
                Surname = lastName,
                Lastname = firstName,
                Email = email
            };

            // Сохранение клиента в базе данных
            App.Database.AddClient(client);

            // Отображение информации о клиенте
            BindingContext = client;
        }

        private void DisplayUserData()
        {
            // Логика отображения данных пользователя
        }

        private void NavigateToAuthenticationPage()
        {

            Navigation.PushAsync(new Registration());
        }

    }
    
}
