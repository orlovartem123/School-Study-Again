using System.Collections.Generic;

namespace SchoolBusinessLogic.BindingModels.Report
{
    public class ReportBindingModel
    {
        public string Filename { get; set; }
        public List<int> SelectedMaterials { get; set; }
    }
}
