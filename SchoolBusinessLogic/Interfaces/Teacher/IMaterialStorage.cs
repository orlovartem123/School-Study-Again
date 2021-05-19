using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System.Collections.Generic;

namespace SchoolBusinessLogic.Interfaces.Teacher
{
    public interface IMaterialStorage
    {
        List<MaterialViewModel> GetFullList();
        List<MaterialViewModel> GetFilteredList(MaterialBindingModel model);
        MaterialViewModel GetElement(MaterialBindingModel model);
        void Insert(MaterialBindingModel model);
        void Update(MaterialBindingModel model);
        void Delete(MaterialBindingModel model);
    }
}
