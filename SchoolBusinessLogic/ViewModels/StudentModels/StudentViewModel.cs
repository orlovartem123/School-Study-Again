using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SchoolBusinessLogic.ViewModels.StudentModels
{
    [DataContract]
    public class StudentViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Grade { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}
