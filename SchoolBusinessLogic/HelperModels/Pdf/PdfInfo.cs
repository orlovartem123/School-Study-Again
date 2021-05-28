using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;

namespace SchoolBusinessLogic.HelperModels.Pdf
{
    public class PdfInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string TeacherName { get; set; }
        public List<ElectiveViewModel> Electives { get; set; }
    }
}
