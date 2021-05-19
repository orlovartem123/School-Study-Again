using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.Interfaces.Teacher;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;

namespace SchoolBusinessLogic.BusinessLogic.TeacherLogics
{
    public class TeacherLogic
    {
        private readonly ITeacherStorage _teacherStorage;

        public TeacherLogic(ITeacherStorage teacherStorage)
        {
            _teacherStorage = teacherStorage;
        }

        public List<TeacherViewModel> Read(TeacherBindingModel model)
        {
            if (model == null)
            {
                return _teacherStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<TeacherViewModel> { _teacherStorage.GetElement(model) };
            }
            return _teacherStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(TeacherBindingModel model)
        {
            var element = _teacherStorage.GetElement(new TeacherBindingModel
            {
                Email = model.Email,
                Login = model.Login
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("There is already a teacher with the same email or login");
            }
            if (model.Id.HasValue)
            {
                _teacherStorage.Update(model);
            }
            else
            {
                _teacherStorage.Insert(model);
            }
        }

        public void Delete(TeacherBindingModel model)
        {
            var element = _teacherStorage.GetElement(new TeacherBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Teacher not found");
            }
            _teacherStorage.Delete(model);
        }
    }
}
