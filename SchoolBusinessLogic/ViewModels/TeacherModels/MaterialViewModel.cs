using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace SchoolBusinessLogic.ViewModels.TeacherModels
{
    [DataContract]
    public class MaterialViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("Matrial Name")]
        public string Name { get; set; }

        [DataMember]
        public decimal Price { get; set; }
    }
}
