using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SchoolBusinessLogic.ViewModels.TeacherModels
{
    [DataContract]
    public class MaterialViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Material Name")]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> MaterialElectives { get; set; }

        [DataMember]
        public DateTime DateCreate { get; set; }
    }
}
