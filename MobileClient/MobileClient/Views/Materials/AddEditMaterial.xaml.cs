using MobileClient.DataContracts;
using MobileClient.Extensions;
using MobileClient.Models.Electives;
using MobileClient.Models.Materials;
using MobileClient.Services;
using MobileClient.Services.Electives;
using MobileClient.Services.Materials;
using MobileClient.Services.Settings;
using MobileClient.ViewModels.Electives;
using MobileClient.ViewModels.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Materials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditMaterial : ContentPage
    {
        public Material Material { get; set; }

        private List<Elective> Electives { get; set; } = new List<Elective>();

        public MultiSelectObservableCollection<Material> MaterialsFromModel { get; }

        private bool _isEditing = false;

        public AddEditMaterial(Material material, MultiSelectObservableCollection<Material> electivesFromModel)
        {
            InitializeComponent();

            Electives = ElectivesService.GetElectivesAsync().GetAwaiter().GetResult();

            var binding = new ElectiveDropDownViewModel
            {
                ElectiveList = Electives
            };
            electivePicker.BindingContext = binding;

            interestsList.BindingContext = new InterestViewModel();
            MaterialsFromModel = electivesFromModel;

            if (material != default)
            {
                _isEditing = true;
                Material = material;

                entryMaterialName.Text = Material.Name;
                entryMaterialPrice.Text = Material.Price.ToString();

                if (material.MaterialElectives != null && material.MaterialElectives.Count > 0)
                {
                    var first = material.MaterialElectives.First();
                    var selected = Electives.Where(x => x.Id == first.Key).FirstOrDefault();
                    if (selected != null)
                    {
                        (electivePicker.BindingContext as ElectiveDropDownViewModel)
                            .SelectedElective = selected;
                        entryElectiveCount.Text = first.Value.Item2.ToString();
                    }

                    foreach (var el in material.MaterialElectives.Skip(1))
                    {
                        if (Electives.Where(x => x.Id == el.Key).FirstOrDefault() != null)
                            container.Children.Add(ContentGenerator.GetAddMaterialsToElectivesBlock(Electives, el.Key, el.Value.Item2));
                    }
                }

                if (material.Interests != null && material.Interests.Count > 0)
                {
                    var selectedIds = material.Interests.Select(x => x.Item1);
                    foreach (var el in (interestsList.BindingContext as InterestViewModel).Interests.Where(x => selectedIds.Contains(x.Data.Id)))
                    {
                        el.IsSelected = true;
                    }
                }
            }
        }

        private async void ButtonSave_Clicked(object sender, EventArgs e)
        {
            var sbErrors = new StringBuilder();

            if (!decimal.TryParse(entryMaterialPrice.Text, out decimal price))
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
                var electiveDict = container.Children
                    .Select(x => (FlexLayout)x)
                    .Select(x =>
                        new
                        {
                            key = (((Picker)x.Children
                                .Where(child => child.GetType() == typeof(Picker))
                                .FirstOrDefault()).BindingContext as ElectiveDropDownViewModel).SelectedElective?.Id,
                            value = Convert.ToInt32(((Entry)x.Children
                                .Where(child => child.GetType() == typeof(Entry))
                                .FirstOrDefault()).Text)
                        }
                     )
                    .Where(x => x.key.HasValue && x.value > 0)
                    .GroupBy(prev => prev.key)
                    .ToDictionary(key => key.Key.Value, value => value.Sum(x => x.value));

                var interestsIds = (interestsList.BindingContext as InterestViewModel).Interests.SelectedItems.Select(x => x.Id).ToList();

                var material = new MaterialContract
                {
                    Name = entryMaterialName.Text,
                    Price = price,
                    TeacherId = teacherId,
                    InterestIds = interestsIds,
                    ElectiveMaterials = electiveDict
                };


                if (_isEditing)
                    material.Id = Material.Id;
                else
                    material.DateCreate = DateTime.Now;

                var result = await MaterialsService.AddEditMaterialAsync(material);
                if (result != null)
                {
                    foreach (var el in result)
                    {
                        sbErrors.AppendLine(el);
                    }

                    errorField.Text = sbErrors.ToString();

                    return;
                }

                await MaterialsFromModel.RefreshAsync(() => MaterialsService.GetMaterialsAsync());
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                errorField.IsVisible = true;
                errorField.Text = ex.Message;
            }
        }

        private void ButtonAddElective_Clicked(object sender, EventArgs e)
        {
            container.Children.Add(ContentGenerator.GetAddMaterialsToElectivesBlock(Electives));
        }

        private async void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}