using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.Interfaces.Teacher
{
    public interface IMedalStorage
    {
        List<MedalViewModel> GetFullList();
        List<MedalViewModel> GetFilteredList(MedalBindingModel model);
        MedalViewModel GetElement(MedalBindingModel model);
        void Insert(MedalBindingModel model);
        void Update(MedalBindingModel model);
        void Delete(MedalBindingModel model);
    }
}
