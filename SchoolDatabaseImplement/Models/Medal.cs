using System.ComponentModel.DataAnnotations;

namespace SchoolDatabaseImplement.Models
{
    public class Medal
    {
        public int Id { get; set; }

        public int TeacherId { get; set; }

        public int ElectiveId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Value { get; set; }

        public virtual Elective Elective { get; set; }

        public virtual Teacher Teacher { get; set; }

    }
}
