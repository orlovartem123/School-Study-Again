using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace SchoolBusinessLogic.ViewModels.StudentModels
{
    [DataContract]
    public class ActivityViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Activity Name")]
        public string Name { get; set; }

        [DataMember]
        public Dictionary<int, string> ActivityElectives { get; set; }
    }
}
