using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SchoolBusinessLogic.BindingModels.TeacherModels
{
    [DataContract]
    public class MedalBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int TeacherId { get; set; }

        [DataMember]
        public int ElectiveId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Value { get; set; }
    }
}
