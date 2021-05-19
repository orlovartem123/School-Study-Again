namespace SchoolDatabaseImplement.Models
{
    public class ActivityElective
    {
        public int Id { get; set; }

        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        public int ElectiveId { get; set; }
        public virtual Elective Elective { get; set; }
    }
}
