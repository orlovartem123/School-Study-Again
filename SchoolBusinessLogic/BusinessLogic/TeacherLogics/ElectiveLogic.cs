using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.Interfaces.Teacher;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.BusinessLogic.TeacherLogics
{
    public class ElectiveLogic
    {
        private readonly IElectiveStorage _electiveStorage;

        public ElectiveLogic(IElectiveStorage electiveStorage)
        {
            _electiveStorage = electiveStorage;
        }

        public List<ElectiveViewModel> Read(ElectiveBindingModel model)
        {
            if (model == null)
            {
                return _electiveStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ElectiveViewModel> { _electiveStorage.GetElement(model) };
            }
            return _electiveStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ElectiveBindingModel model)
        {
            var element = _electiveStorage.GetElement(new ElectiveBindingModel
            {
                Name = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("There is already a elective with the same name");
            }
            if (model.Id.HasValue)
            {
                _electiveStorage.Update(model);
            }
            else
            {
                _electiveStorage.Insert(model);
            }
        }

        public void Delete(ElectiveBindingModel model)
        {
            var element = _electiveStorage.GetElement(new ElectiveBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Elective not found");
            }
            _electiveStorage.Delete(model);
        }
    }
}
