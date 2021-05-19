using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDatabaseImplement.Models
{
    public class Interest
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("InterestId")]
        public virtual List<MaterialInterest> MaterialInterests { get; set; }

        public virtual Student Student { get; set; }
    }
}
