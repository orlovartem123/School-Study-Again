using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SchoolBusinessLogic.BindingModels.StudentModels
{
    [DataContract]
    public class ActivityBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int StudentId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Dictionary<int, string> Electives { get; set; }
    }
}
