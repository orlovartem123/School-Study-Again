
using MobileClient.DataContracts;
using MobileClient.Extensions;
using MobileClient.Models.Medals;
using MobileClient.Services.Electives;
using MobileClient.Services.Medals;
using MobileClient.Services.Settings;
using MobileClient.ViewModels.Electives;
using System;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Medals
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditMedal : ContentPage
    {
        public Medal Medal { get; set; }

        public MultiSelectObservableCollection<Medal> MedalsFromModel { get; }

        private bool _isEditing = false;

        public AddEditMedal(Medal medal, MultiSelectObservableCollection<Medal> electivesFromModel)
        {
            InitializeComponent();

            var list = ElectivesService.GetElectivesAsync().GetAwaiter().GetResult();

            var binding = new ElectiveDropDownViewModel
            {
                ElectiveList = list
            };

            MedalsFromModel = electivesFromModel;

            if (medal != default)
            {
                _isEditing = true;
                Medal = medal;

                entryMedalName.Text = Medal.Name;
                entryMedalPrice.Text = Medal.Value.ToString();

                var elem = medal.ElectiveId.HasValue ?
                    ElectivesService.GetElectiveAsync(medal.ElectiveId.Value).GetAwaiter().GetResult() : null;
                binding.SelectedElective = list.Where(x => x.Id == elem.Id).FirstOrDefault();
            }

            electivePicker.BindingContext = binding;
        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            var sbErrors = new StringBuilder();

            if (!int.TryParse(entryMedalPrice.Text, out int value))
            {
                sbErrors.AppendLine("Incorrect value format");
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
                var medal = new MedalContract
                {
                    Name = entryMedalName.Text,
                    Value = value,
                    TeacherId = teacherId,
                    ElectiveId = (electivePicker.BindingContext as ElectiveDropDownViewModel).SelectedElective?.Id
                };

                if (_isEditing)
                    medal.Id = Medal.Id;

                var result = await MedalsService.AddEditMedalAsync(medal);
                if (result != null)
                {
                    foreach (var el in result)
                    {
                        sbErrors.AppendLine(el);
                    }

                    errorField.Text = sbErrors.ToString();

                    return;
                }

                await MedalsFromModel.RefreshAsync(() => MedalsService.GetMedalsAsync());
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