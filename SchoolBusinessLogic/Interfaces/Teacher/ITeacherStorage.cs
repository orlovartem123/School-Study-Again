using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System.Collections.Generic;

namespace SchoolBusinessLogic.Interfaces.Teacher
{
    public interface ITeacherStorage
    {
        List<TeacherViewModel> GetFullList();
        List<TeacherViewModel> GetFilteredList(TeacherBindingModel model);
        TeacherViewModel GetElement(TeacherBindingModel model);
        TeacherViewModel GetByExtId(string extId);
        void Insert(TeacherBindingModel model);
        void Update(TeacherBindingModel model);
        void Delete(TeacherBindingModel model);
        TeacherViewModel InsertWithResult(TeacherBindingModel model);
    }
}
