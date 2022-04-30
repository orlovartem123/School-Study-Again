using MobileClient.Models.Materials;
using MobileClient.Services.Materials;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms.MultiSelectListView;

namespace MobileClient.ViewModels.Materials
{
    public class InterestViewModel : INotifyPropertyChanged
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

        public MultiSelectObservableCollection<Interest> Interests { get; }

        public InterestViewModel()
        {
            Interests = new MultiSelectObservableCollection<Interest>();
            var fromApi = MaterialsService.GetInterestsAsync().GetAwaiter().GetResult();
            foreach (var elem in fromApi)
            {
                Interests.Add(elem);
            }
        }
    }
}
