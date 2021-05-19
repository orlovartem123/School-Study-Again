using System.Runtime.Serialization;

namespace SchoolBusinessLogic.BindingModels.StudentModels
{

    [DataContract]
    public class StudentBindingModel
    {
        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Grade { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }
    }

}
