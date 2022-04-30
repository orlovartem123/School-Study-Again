using MobileClient.Extensions;
using MobileClient.Models.Materials;
using MobileClient.Services.Materials;
using MobileClient.Views.Materials;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace MobileClient.ViewModels.Materials
{
    public class MaterialViewModel : INotifyPropertyChanged
    {
        #region Property

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        public MultiSelectObservableCollection<Material> Materials { get; }

        public MaterialViewModel()
        {
            Materials = new MultiSelectObservableCollection<Material>();
            var fromApi = MaterialsService.GetMaterialsAsync().GetAwaiter().GetResult();
            foreach (var elem in fromApi)
            {
                Materials.Add(elem);
            }
        }

        public ICommand EditMaterialCommand => new Command(async () =>
        {
            var selected = Materials.SelectedItems.FirstOrDefault();

            if (selected == null) return;

            var editPage = new AddEditMaterial(selected, Materials);
            await Application.Current.MainPage.Navigation.PushAsync(editPage);
        });

        public ICommand AddMaterialCommand => new Command<Material>(async elective =>
        {
            var addPage = new AddEditMaterial(null, Materials);
            await Application.Current.MainPage.Navigation.PushAsync(addPage);
        });

        public ICommand DeleteMaterialCommand => new Command<Material>(async elective =>
        {
            var idsForDelete = Materials.SelectedItems.Select(e => e.Id).ToList();
            if (idsForDelete.Count == 0)
                return;

            var delete = await Application.Current.MainPage.DisplayAlert(Resource.AlertDelete,
                $"{Resource.AlertDeletePref} {idsForDelete.Count} {Resource.AlertDeletePost}", Resource.Yes, Resource.No);
            if (delete)
            {
                await MaterialsService.DeleteMaterialsAsync(idsForDelete);
            }

            await Materials.RefreshAsync(() => MaterialsService.GetMaterialsAsync());
        });
    }
}
