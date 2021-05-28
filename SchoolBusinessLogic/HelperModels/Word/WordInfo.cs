﻿using SchoolBusinessLogic.ViewModels.StudentModels;
using System.Collections.Generic;

namespace SchoolBusinessLogic.HelperModels.Word
{
    public class ExlelInfo
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ActivityViewModel> Activities { get; set; }
    }
}
