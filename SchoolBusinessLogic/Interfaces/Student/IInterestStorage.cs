using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.ViewModels.StudentModels;
using System.Collections.Generic;

namespace SchoolBusinessLogic.Interfaces.Student
{
    public interface IInterestStorage
    {
        List<InterestViewModel> GetFullList();
        List<InterestViewModel> GetFilteredList(InterestBindingModel model);
        InterestViewModel GetElement(InterestBindingModel model);
        void Insert(InterestBindingModel model);
        void Update(InterestBindingModel model);
        void Delete(InterestBindingModel model);
    }
}
