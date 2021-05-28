using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SchoolBusinessLogic.BindingModels.TeacherModels
{
    [DataContract]
    public class BindActivityWithElectivesBindingModel
    {
        [DataMember]
        public int? ActivityId { get; set; }

        [DataMember]
        public List<int> Electives { get; set; }
    }
}
