using MobileClient.DataContracts;
using MobileClient.Extensions;
using MobileClient.Models.Electives;
using MobileClient.Services.Electives;
using MobileClient.Services.Settings;
using System;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Electives
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditElective : ContentPage
    {
        public Elective Elective { get; set; }

        public MultiSelectObservableCollection<Elective> ElectivesFromModel { get; }

        private bool _isEditing = false;

        public AddEditElective(Elective elective, MultiSelectObservableCollection<Elective> electivesFromModel)
        {
            InitializeComponent();

            ElectivesFromModel = electivesFromModel;

            if (elective != default)
            {
                _isEditing = true;
                Elective = elective;
                entryElectiveName.Text = Elective.Name;
                entryElectivePrice.Text = Elective.Price.ToString();
            }
        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            var sbErrors = new StringBuilder();

            if (!decimal.TryParse(entryElectivePrice.Text, out decimal price))
            {
                sbErrors.AppendLine("Incorrect price format");
            }

            if (!int.TryParse(LocalPropsProviderService.TeacherId, out int teacherId))
            {
                sbErrors.AppendLine("Cant get teacherId");
            }

            if (!string.IsNullOrEmpty(sbErrors.ToString()))
            {
                errorField.IsVisible = true;
                errorField.Text = sbErrors.ToString();
                return;
            }

            try
            {
                var elective = new ElectiveContract
                {
                    Name = entryElectiveName.Text,
                    Price = price,
                    TeacherId = teacherId,
                    DateCreate = DateTime.Now
                };

                if (_isEditing)
                    elective.Id = Elective.Id;

                var result = await ElectivesService.AddEditElectiveAsync(elective);
                if (result != null)
                {
                    foreach (var el in result)
                    {
                        sbErrors.AppendLine(el);
                    }

                    errorField.Text = sbErrors.ToString();

                    return;
                }

                await ElectivesFromModel.RefreshAsync(() => ElectivesService.GetElectivesAsync());
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                errorField.IsVisible = true;
                errorField.Text = ex.Message;
            }
        }

        private async void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}