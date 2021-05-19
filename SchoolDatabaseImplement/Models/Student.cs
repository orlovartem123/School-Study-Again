using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDatabaseImplement.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Grade { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }

        [ForeignKey("StudentId")]
        public virtual List<Activity> Activities { get; set; }

        [ForeignKey("StudentId")]
        public virtual List<Interest> Interests { get; set; }
    }
}
