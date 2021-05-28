using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolDatabaseImplement.Models
{
    public class Elective
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime DateCreate { get; set; }

        [ForeignKey("ElectiveId")]
        public virtual List<Medal> Medals { get; set; }

        [ForeignKey("ElectiveId")]
        public virtual List<ElectiveMaterial> ElectiveMaterials { get; set; }

        [ForeignKey("ElectiveId")]
        public virtual List<ActivityElective> ActivityElectives { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
