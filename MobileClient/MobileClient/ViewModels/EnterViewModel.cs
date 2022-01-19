using MobileClient.Views;
using Xamarin.Forms;

namespace MobileClient.ViewModels
{
    public class EnterViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public Command RegisterCommand { get; }

        public EnterViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnREgisterClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private async void OnREgisterClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }
    }
}
