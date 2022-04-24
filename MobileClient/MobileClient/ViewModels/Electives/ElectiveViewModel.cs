using MobileClient.Extensions;
using MobileClient.Models.Electives;
using MobileClient.Services.Electives;
using MobileClient.Views.Electives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.MultiSelectListView;

namespace MobileClient.ViewModels.Electives
{
    public class ElectiveViewModel : INotifyPropertyChanged
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

        public MultiSelectObservableCollection<Elective> Electives { get; }

        public ElectiveViewModel()
        {
            Electives = new MultiSelectObservableCollection<Elective>();
            var fromApi = ElectivesService.GetElectivesAsync().GetAwaiter().GetResult();
            foreach (var elem in fromApi)
            {
                Electives.Add(elem);
            }
        }

        public ICommand EditElectiveCommand => new Command(async () =>
        {
            var selected = Electives.SelectedItems.FirstOrDefault();

            if (selected == null) return;

            var editPage = new AddEditElective(selected, Electives);
            await Application.Current.MainPage.Navigation.PushAsync(editPage);
        });

        public ICommand AddElectiveCommand => new Command<Elective>(async elective =>
        {
            var addPage = new AddEditElective(null, Electives);
            await Application.Current.MainPage.Navigation.PushAsync(addPage);
        });

        public ICommand DeleteElectiveCommand => new Command<Elective>(async elective =>
        {
            var idsForDelete = Electives.SelectedItems.Select(e => e.Id).ToList();
            if (idsForDelete.Count == 0)
                return;

            var delete = await Application.Current.MainPage.DisplayAlert("Delete", $"Delete {idsForDelete.Count} items?", "Yes", "No");
            if (delete)
            {
                await ElectivesService.DeleteElectivesAsync(idsForDelete);
            }

            await Electives.RefreshAsync(() => ElectivesService.GetElectivesAsync());
        });
    }
}
