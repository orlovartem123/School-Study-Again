using MobileClient.Extensions;
using MobileClient.Models.Medals;
using MobileClient.Services.Medals;
using MobileClient.Views.Medals;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace MobileClient.ViewModels.Medals
{
    public class MedalViewModel : INotifyPropertyChanged
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

        public MultiSelectObservableCollection<Medal> Medals { get; }

        public MedalViewModel()
        {
            Medals = new MultiSelectObservableCollection<Medal>();
            var fromApi = MedalsService.GetMedalsAsync().GetAwaiter().GetResult();
            foreach (var elem in fromApi)
            {
                Medals.Add(elem);
            }
        }

        public ICommand EditMedalCommand => new Command(async () =>
        {
            var selected = Medals.SelectedItems.FirstOrDefault();

            if (selected == null) return;

            var editPage = new AddEditMedal(selected, Medals);
            await Application.Current.MainPage.Navigation.PushAsync(editPage);
        });

        public ICommand AddMedalCommand => new Command<Medal>(async elective =>
        {
            var addPage = new AddEditMedal(null, Medals);
            await Application.Current.MainPage.Navigation.PushAsync(addPage);
        });

        public ICommand DeleteMedalCommand => new Command<Medal>(async elective =>
        {
            var idsForDelete = Medals.SelectedItems.Select(e => e.Id).ToList();
            if (idsForDelete.Count == 0)
                return;

            var delete = await Application.Current.MainPage.DisplayAlert(Resource.AlertDelete,
                $"{Resource.AlertDeletePref} {idsForDelete.Count} {Resource.AlertDeletePost}", Resource.Yes, Resource.No);
            if (delete)
            {
                await MedalsService.DeleteMedalsAsync(idsForDelete);
            }

            await Medals.RefreshAsync(() => MedalsService.GetMedalsAsync());
        });
    }
}
