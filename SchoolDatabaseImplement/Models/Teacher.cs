using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDatabaseImplement.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Position { get; set; }

        public string ExtId { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("TeacherId")]
        public virtual List<Material> Materials { get; set; }

        [ForeignKey("TeacherId")]
        public virtual List<Elective> Electives { get; set; }

        [ForeignKey("TeacherId")]
        public virtual List<Medal> Medals { get; set; }
    }
}
