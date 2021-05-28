using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.BindingModels.Report
{
    public class PdfReportBindingModel
    {
        public string FileName { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string TeacherName { get; set; }
    }
}
