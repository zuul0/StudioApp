using EbApp.Models;
using System;
using System.Net;
using System.Net.Mail;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Text.Json;
using Newtonsoft.Json;


namespace EbApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registration : ContentPage
    {
        private string verificationCode;
        private string email;

        public Registration()
        {
            InitializeComponent();
        }

        private bool IsEmailValid(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        private async void SendEmailButton_Clicked(object sender, EventArgs e)
        {
            email = EmailEntry.Text.Trim();
            if (!string.IsNullOrWhiteSpace(email) && IsEmailValid(email))
            {
                try
                {
                    Random random = new Random();
                    verificationCode = random.Next(100000, 999999).ToString();

                    MailAddress from = new MailAddress("akmilia@yandex.ru", "Kamila Gayalieva");
                    MailAddress to = new MailAddress(email);
                    MailMessage m = new MailMessage(from, to);
                    m.Body = verificationCode;
                    m.Subject = "Код подтверждения";
                    m.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
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


        private async void ButtonNext_Clicked(object sender, EventArgs e)
        {
            string enteredCode = CodeEntry.Text;

            if (enteredCode == verificationCode)
            {
                Client client = App.Database.GetClientByEmail(email);
                if (client == null)
                {
                    Client client1 = new Client
                    {
                        Email = email,
                        Surname = "",
                        Patronymic = "",
                        Lastname = ""
                    };
                    client = client1;
                    App.database.AddClient(client);
                }
                Application.Current.Properties["currentUser"] = JsonConvert.SerializeObject(client);
                await Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("Ошибка", "Введенный код неверный. Попробуйте снова.", "OK");
                CodeEntry.Text = "";
            }
        }

    }
}

