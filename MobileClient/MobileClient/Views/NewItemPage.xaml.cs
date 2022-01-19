using MobileClient.Models;
using MobileClient.ViewModels;
using Xamarin.Forms;

namespace MobileClient.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}