using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDatabaseImplement.Models
{
    public class Activity
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("ActivityId")]
        public virtual List<ActivityElective> ActivityElectives { get; set; }

        public virtual Student Student { get; set; }
    }
}
