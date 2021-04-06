using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class ElectiveMaterial
    {
        public int Id { get; set; }

        public int ElectiveId { get; set; }
        public virtual Elective Elective { get; set; }

        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }

        [Required]
        public int MaterialCount { get; set; }
    }
}
