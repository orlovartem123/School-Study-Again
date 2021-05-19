﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SchoolBusinessLogic.ViewModels.TeacherModels
{
    [DataContract]
    public class ElectiveViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Elective Name")]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> ElectiveMaterials { get; set; }

        [DataMember]
        public Dictionary<int, string> ElectiveActivities { get; set; }
    }
}
