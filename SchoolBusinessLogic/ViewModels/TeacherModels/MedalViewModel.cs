using System.ComponentModel;
using System.Runtime.Serialization;

namespace SchoolBusinessLogic.ViewModels.TeacherModels
{
    [DataContract]
    public class MedalViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Medal Name")]
        public string Name { get; set; }

        [DataMember]
        public int Value { get; set; }

        [DataMember]
        public int? ElectiveId { get; set; }

        [DataMember]
        [DisplayName("ElectiveName")]
        public string ElectiveName { get; set; }
    }
}
