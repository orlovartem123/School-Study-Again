using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.ViewModels.StudentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.Interfaces.Student
{
    public interface IActivityStorage
    {
        List<ActivityViewModel> GetFullList();
        List<ActivityViewModel> GetFilteredList(ActivityBindingModel model);
        ActivityViewModel GetElement(ActivityBindingModel model);
        void Insert(ActivityBindingModel model);
        void Update(ActivityBindingModel model);
        void Delete(ActivityBindingModel model);
    }
}
