namespace SchoolDatabaseImplement.Models
{
    public class MaterialInterest
    {
        public int Id { get; set; }

        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }

        public int InterestId { get; set; }
        public virtual Interest Interest { get; set; }
    }
}
