using MobileClient.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Auth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterButton_Clicked(object sender, EventArgs e)
        {
            var errors = new StringBuilder();

            var model = new Models.Auth.SignUpModel
            {
                Login = entryLogin.Text,
                Password = entryPassword.Text,
                ConfirmPassword = entryPasswordConfirm.Text,
            };

            errors.Append(model.Validate());

            if (string.IsNullOrEmpty(errors.ToString()))
            {
                errors.Append(await AuthService.TrySignUp(model));
                if (string.IsNullOrEmpty(errors.ToString()))
                    await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }

            errorField.IsVisible = true;
            errorField.Text = errors.ToString();
        }
    }
}