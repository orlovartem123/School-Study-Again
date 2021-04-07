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
        private readonly IActivityStorage _activityStorage;

        public ActivityLogic(IActivityStorage activityStorage)
        {
            _activityStorage = activityStorage;
        }

        public List<ActivityViewModel> Read(ActivityBindingModel model)
        {
            if (model == null)
            {
                return _activityStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ActivityViewModel> { _activityStorage.GetElement(model) };
            }
            return _activityStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(ActivityBindingModel model)
        {
            var element = _activityStorage.GetElement(new ActivityBindingModel
            {
                Name = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("There is already a activity with the same name");
            }
            if (model.Id.HasValue)
            {
                _activityStorage.Update(model);
            }
            else
            {
                _activityStorage.Insert(model);
            }
        }

        public void Delete(ActivityBindingModel model)
        {
            var element = _activityStorage.GetElement(new ActivityBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Activity not found");
            }
            _activityStorage.Delete(model);
        }
    }
}
