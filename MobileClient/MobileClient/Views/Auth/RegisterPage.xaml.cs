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

        private async void ToShell(object sender, EventArgs e)
        {
            //await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            await Navigation.PushAsync(new AppShell());
        }
    }
}