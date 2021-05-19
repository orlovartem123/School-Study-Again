using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SchoolBusinessLogic.BindingModels.TeacherModels
{
    [DataContract]
    public class ElectiveBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int? TeacherId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public List<int> Activities { get; set; }
    }
}
