using MobileClient.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MobileClient.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}