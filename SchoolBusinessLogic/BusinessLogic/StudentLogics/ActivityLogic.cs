using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.Interfaces.Student;
using SchoolBusinessLogic.ViewModels.StudentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.BusinessLogic.StudentLogics
{
    public class ActivityLogic
    {
        private readonly IActivityStorage _materialStorage;

        public ActivityLogic(IActivityStorage materialStorage)
        {
            _materialStorage = materialStorage;
        }

        public List<ActivityViewModel> Read(ActivityBindingModel model)
        {
            if (model == null)
            {
                return _materialStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ActivityViewModel> { _materialStorage.GetElement(model) };
            }
            return _materialStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ActivityBindingModel model)
        {
            var element = _materialStorage.GetElement(new ActivityBindingModel
            {
                Name = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("There is already a material with the same name");
            }
            if (model.Id.HasValue)
            {
                _materialStorage.Update(model);
            }
            else
            {
                _materialStorage.Insert(model);
            }
        }

        public void Delete(ActivityBindingModel model)
        {
            var element = _materialStorage.GetElement(new ActivityBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Element not found");
            }
            _materialStorage.Delete(model);
        }
    }
}
