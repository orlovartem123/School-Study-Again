using MobileClient.ViewModels.Medals;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Medals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MedalsList : ContentPage
    {
        public MedalsList()
        {
            InitializeComponent();
            BindingContext = new MedalViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new MedalViewModel();
        }
    }
}
