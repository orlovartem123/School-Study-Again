using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.Interfaces.Student;
using SchoolBusinessLogic.ViewModels.StudentModels;
using System;
using System.Collections.Generic;

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
            return _activityStorage.GetFullList();
        }

        public void CreateOrUpdate(ActivityBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(ActivityBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
