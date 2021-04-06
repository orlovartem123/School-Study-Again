using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.ViewModels.StudentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.Interfaces.Student
{
    public interface IStudentStorage
    {
        List<StudentViewModel> GetFullList();
        List<StudentViewModel> GetFilteredList(StudentBindingModel model);
        StudentViewModel GetElement(StudentBindingModel model);
        void Insert(StudentBindingModel model);
        void Update(StudentBindingModel model);
        void Delete(StudentBindingModel model);
    }
}
