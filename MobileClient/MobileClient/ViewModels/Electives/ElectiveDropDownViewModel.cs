using MobileClient.Models.Electives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileClient.ViewModels.Electives
{
    public class ElectiveDropDownViewModel : INotifyPropertyChanged
    {
        List<Elective> electiveList;
        public List<Elective> ElectiveList
        {
            get { return electiveList; }
            set
            {
                if (electiveList != value)
                {
                    electiveList = value;
                    OnPropertyChanged();
                }
            }
        }

        Elective selectedElective;
        public Elective SelectedElective
        {
            get { return selectedElective; }
            set
            {
                if (selectedElective != value)
                {
                    selectedElective = value;
                    OnPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
