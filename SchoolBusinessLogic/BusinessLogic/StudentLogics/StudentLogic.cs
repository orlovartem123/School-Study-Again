using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.Interfaces.Student;
using SchoolBusinessLogic.ViewModels.StudentModels;
using System;
using System.Collections.Generic;

namespace SchoolBusinessLogic.BusinessLogic.StudentLogics
{
    public class StudentLogic
    {
        private readonly IStudentStorage _studentStorage;

        public StudentLogic(IStudentStorage studentStorage)
        {
            _studentStorage = studentStorage;
        }

        public List<StudentViewModel> Read(StudentBindingModel model)
        {
            if (model == null)
            {
                return _studentStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<StudentViewModel> { _studentStorage.GetElement(model) };
            }
            return _studentStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(StudentBindingModel model)
        {
            var element = _studentStorage.GetElement(new StudentBindingModel
            {
                Email = model.Email,
                Login = model.Login
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("There is already a student with the same email or login");
            }
            if (model.Id.HasValue)
            {
                _studentStorage.Update(model);
            }
            else
            {
                _studentStorage.Insert(model);
            }
        }

        public void Delete(StudentBindingModel model)
        {
            var element = _studentStorage.GetElement(new StudentBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Student not found");
            }
            _studentStorage.Delete(model);
        }
    }
}
