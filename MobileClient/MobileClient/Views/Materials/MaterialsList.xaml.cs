using MobileClient.ViewModels.Materials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Materials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialsList : ContentPage
    {
        public MaterialsList()
        {
            InitializeComponent();
            BindingContext = new MaterialViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new MaterialViewModel();
        }
    }
}
