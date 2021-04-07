﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SchoolBusinessLogic.BindingModels.TeacherModels
{
    [DataContract]
    public class MaterialBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public int TeacherId { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
