using MobileClient.Services.Settings;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileClient.ViewModels.About
{
    public class AboutViewModel : INotifyPropertyChanged
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

        private string Name { get; set; } = "NoName";

        private string Surname { get; set; } = "NoName";

        public string WelcomeText { get => $"{Resource.Welcome} {Name} {Surname}!"; }

        public AboutViewModel()
        {
            var teacherInfo = LocalPropsProviderService.UserName;
            if (teacherInfo != default)
            {
                Name = teacherInfo.Split(' ')[0];
                Surname = teacherInfo.Split(' ')[1];
            }
        }
    }
}
