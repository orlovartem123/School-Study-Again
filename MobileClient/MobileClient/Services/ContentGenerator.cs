using MobileClient.Models.Electives;
using MobileClient.ViewModels.Electives;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileClient.Services
{
    public class ContentGenerator
    {
        public static FlexLayout GetAddMaterialsToElectivesBlock(List<Elective> itemsSource)
        {
            FlexLayout flexLayout = new FlexLayout();
            flexLayout.JustifyContent = FlexJustify.SpaceBetween;

            var pickerBinding = new ElectiveDropDownViewModel
            {
                ElectiveList = itemsSource
            };

            var pickerBindingForItemSource = new Binding { Source = pickerBinding, Path = "ElectiveList" };
            var pickerBindingForSelectedItem = new Binding { Source = pickerBinding, Path = "SelectedElective" };
            var pickerBindingForItemDisplayBinding = new Binding { Source = pickerBinding.SelectedElective, Path = "Name" };

            var picker = new Picker();
            picker.BindingContext = pickerBinding;
            picker.Title = Resource.SelectElective;
            picker.SetBinding(Picker.ItemsSourceProperty, pickerBindingForItemSource);
            picker.SetBinding(Picker.SelectedItemProperty, pickerBindingForSelectedItem);
            picker.ItemDisplayBinding = pickerBindingForItemDisplayBinding;
            picker.WidthRequest = 200;

            var entry = new Entry();
            entry.Text = "1";
            entry.WidthRequest = 80;
            entry.SetOnAppTheme(Entry.TextColorProperty,
                (Color)Application.Current.Resources["Background_d"], (Color)Application.Current.Resources["Background_l"]);
            entry.FontSize = (double)new FontSizeConverter().ConvertFromInvariantString("Medium");

            var button = new Button();
            button.Text = "-";
            button.WidthRequest = 45;
            button.HeightRequest = 45;
            button.Margin = new Thickness(0, 20, 0, 0);
            button.VerticalOptions = LayoutOptions.Center;
            button.Clicked += Button_Clicked;
            button.CornerRadius = 10;

            flexLayout.Children.Add(picker);
            flexLayout.Children.Add(entry);
            flexLayout.Children.Add(button);

            return flexLayout;
        }

        private static void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;

            var flexLayout = button.Parent;

            var container = (StackLayout)flexLayout.Parent;

            container.Children.Remove((FlexLayout)flexLayout);
        }
    }
}
