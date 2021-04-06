using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.Interfaces.Teacher
{
    public interface ITeacherStorage
    {
        List<TeacherViewModel> GetFullList();
        List<TeacherViewModel> GetFilteredList(TeacherBindingModel model);
        TeacherViewModel GetElement(TeacherBindingModel model);
        void Insert(TeacherBindingModel model);
        void Update(TeacherBindingModel model);
        void Delete(TeacherBindingModel model);
    }
}
