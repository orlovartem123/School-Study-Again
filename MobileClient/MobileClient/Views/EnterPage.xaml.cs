using MobileClient.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EnterPage : ContentPage
    {
        public EnterPage()
        {
            InitializeComponent();
            this.BindingContext = new EnterViewModel();
        }
    }
}