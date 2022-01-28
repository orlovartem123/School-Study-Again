using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SchoolBusinessLogic.BindingModels.TeacherModels
{
    [DataContract]
    public class MaterialBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string TeacherId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public DateTime DateCreate { get; set; }

        [DataMember]
        public DateTime? DateFrom { get; set; }

        [DataMember]
        public DateTime? DateTo { get; set; }

        [DataMember]
        public int? ToSkip { get; set; }

        [DataMember]
        public int? ToTake { get; set; }

        [DataMember]
        public List<int> InterestIds { get; set; }

        [DataMember]
        public Dictionary<int, int> ElectiveMaterials { get; set; }
    }
}
