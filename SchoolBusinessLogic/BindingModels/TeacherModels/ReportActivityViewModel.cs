using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.BindingModels.TeacherModels
{
    public class ReportActivityViewModel
    {
        public string AcitivityName { get; set; }

        public int TotalCount { get; set; }

        public List<string> Electives { get; set; }
    }
}
