using MobileClient.Models.Electives;
using MobileClient.Services.Electives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileClient.Views.Electives
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditElective : ContentPage
    {
        public ElectiveViewModel Elective { get; set; }

        private bool _isEditing = false;

        public AddEditElective(int? electiveId)
        {
            InitializeComponent();
            if (electiveId.HasValue)
            {
                _isEditing = true;
                Elective = ElectivesService.GetElectiveAsync(electiveId.Value).GetAwaiter().GetResult();
            }
        }


    }
}