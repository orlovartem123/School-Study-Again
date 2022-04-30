using MobileClient.ViewModels.Electives;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Electives
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElectivesList : ContentPage
    {
        public ElectivesList()
        {
            InitializeComponent();
            BindingContext = new ElectiveViewModel();
        }
    }
}
