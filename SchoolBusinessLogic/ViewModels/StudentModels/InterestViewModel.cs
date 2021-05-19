using System.Runtime.Serialization;

namespace SchoolBusinessLogic.ViewModels.StudentModels
{
    [DataContract]
    public class InterestViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
