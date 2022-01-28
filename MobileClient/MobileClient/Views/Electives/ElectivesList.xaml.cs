using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Electives
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElectivesList : ContentPage
    {
        public ObservableCollection<Class1> Items { get; set; }

        public ElectivesList()
        {
            InitializeComponent();

            Items = new ObservableCollection<Class1>
            {
                new Class1{Name="fff",Age=5},
                new Class1{Name="s",Age=5},
                new Class1{Name="3",Age=2},
                new Class1{Name="f",Age=1},
               new Class1{Name="hfg",Age=5},
            };

            MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
    }

    public class Class1
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
