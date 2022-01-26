using MobileClient.DataContracts;
using MobileClient.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileClient.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            ApiClient.ConnectApi((string)Application.Current.Properties["authToken"]);

            var result = await ApiClient.GetRequest<CustomHttpResponse>("Teacher/Ping");
        }
    }
}