using MobileClient.ViewModels.About;
using Xamarin.Forms;

namespace MobileClient.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = new AboutViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new AboutViewModel();
        }
    }
}