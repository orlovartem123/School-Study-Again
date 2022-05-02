using System.Text;

namespace MobileClient.Models.Auth
{
    public class TeacherInfo
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Position { get; set; }

        public string Validate()
        {
            var errors = new StringBuilder();

            if (string.IsNullOrEmpty(Name))
                errors.AppendLine(Resource.EmptyNameError);

            if (string.IsNullOrEmpty(Surname))
                errors.AppendLine(Resource.EmptySurNameError);

            return errors.ToString();
        }
    }
}
