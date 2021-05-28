using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.ViewModels.Diagram
{
    public class DiagramDataViewModel
    {
        public string ColumnName { get; set; }

        public string ValueName { get; set; }

        public string Title { get; set; }

        public Dictionary<string,int> Data { get; set; }
    }
}
