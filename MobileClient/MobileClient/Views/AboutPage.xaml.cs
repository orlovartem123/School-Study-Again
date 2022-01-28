using MobileClient.DataContracts;
using MobileClient.Services;
using MobileClient.Services.Settings;
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
            ApiClient.ConnectApi(LocalPropsProviderService.AuthToken);

            var teacherId = LocalPropsProviderService.TeacherId;

            var result = await ApiClient.GetRequest("api/Teacher/Ping");
        }
    }
}