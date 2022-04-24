using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System.Collections.Generic;

namespace SchoolBusinessLogic.Interfaces.Teacher
{
    public interface IElectiveStorage
    {
        List<ElectiveViewModel> GetFullList();
        List<ElectiveViewModel> GetFilteredList(ElectiveBindingModel model);
        ElectiveViewModel GetElement(ElectiveBindingModel model);
        void Insert(ElectiveBindingModel model);
        void Update(ElectiveBindingModel model);
        void Delete(ElectiveBindingModel model);
        void DeleteMany(IList<int> ids);
        void BindActivityWithElectives(BindActivityWithElectivesBindingModel model);
    }
}
