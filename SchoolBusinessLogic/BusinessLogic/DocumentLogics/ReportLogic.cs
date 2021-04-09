using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.Interfaces.Student;
using SchoolBusinessLogic.Interfaces.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolBusinessLogic.BusinessLogic.DocumentLogics
{
    public class ReportLogic
    {
        private readonly IActivityStorage _activityStorage;
        private readonly IElectiveStorage _electiveStorage;

        public ReportLogic(IActivityStorage activityStorage, IElectiveStorage electiveStorage)
        {
            _activityStorage = activityStorage;
            _electiveStorage = electiveStorage;
        }

        public List<ReportActivityViewModel> GetActivityElectives(ActivityBindingModel filter)
        {
            var activities = _activityStorage.GetFilteredList(filter);
            var list = new List<ReportActivityViewModel>();
            foreach (var actvity in activities)
            {
                var record = new ReportActivityViewModel
                {
                    AcitivityName = actvity.Name,
                    Electives = new List<string>(),
                };
                foreach (var elective in actvity.ActivityElectives)
                {

                    record.Electives.Add(elective.Value);

                }
                list.Add(record);
            }
            return list;
        }
    }
}
