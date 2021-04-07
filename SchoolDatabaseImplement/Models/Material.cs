using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolDatabaseImplement.Models
{
    public class Material
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        [ForeignKey("MaterialId")]
        public virtual List<ElectiveMaterial> ElectiveMaterials { get; set; }

        [ForeignKey("MaterialId")]
        public virtual List<MaterialInterest> MaterialInterests { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
