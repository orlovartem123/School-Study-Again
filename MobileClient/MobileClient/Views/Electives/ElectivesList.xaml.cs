using MobileClient.Models.Electives;
using MobileClient.Services.Electives;
using MobileClient.ViewModels.Electives;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Electives
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElectivesList : ContentPage
    {
        public ObservableCollection<Elective> Items { get; set; } = new ObservableCollection<Elective>();

        public ElectivesList()
        {
            InitializeComponent();
            BindingContext = new ElectiveViewModel();
        }

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    Items.Clear();
        //    var electives = ElectivesService.GetElectivesAsync().GetAwaiter().GetResult();
        //    foreach (var elem in electives)
        //    {
        //        Items.Add(elem);
        //    }
        //    MyListView.ItemsSource = Items;
        //}

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //if (e.Item == null)
            //    return;

            //var elem = e.Item as Elective;

            //var editPage = new AddEditElective(elem.Id);
            //await Navigation.PushAsync(editPage);

            ////Deselect Item
            //((ListView)sender).SelectedItem = null;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //var addingPage = new AddEditElective(null);
            //await Navigation.PushAsync(addingPage);
        }
    }
}
