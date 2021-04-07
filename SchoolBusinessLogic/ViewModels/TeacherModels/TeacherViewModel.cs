using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SchoolBusinessLogic.ViewModels.TeacherModels
{
    [DataContract]
    public class TeacherViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Position { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}
