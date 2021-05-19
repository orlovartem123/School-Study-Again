using Microsoft.EntityFrameworkCore;
using SchoolDatabaseImplement.Models;

namespace SchoolDatabaseImplement
{
    public class SchoolDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"data source='LAPTOP-4UI9Q996\SQLEXPRESS'; initial catalog='SchoolDatabase'; user id='sa'; password='123123'; Persist Security Info='True'; Connect Timeout='60';");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Activity> Activities { set; get; }
        public virtual DbSet<ActivityElective> ActivityElectives { set; get; }
        public virtual DbSet<Elective> Electives { set; get; }
        public virtual DbSet<ElectiveMaterial> ElectiveMaterials { set; get; }
        public virtual DbSet<Interest> Interests { set; get; }
        public virtual DbSet<Material> Materials { set; get; }
        public virtual DbSet<MaterialInterest> MaterialInterests { set; get; }
        public virtual DbSet<Medal> Medals { set; get; }
        public virtual DbSet<Student> Students { set; get; }
        public virtual DbSet<Teacher> Teachers { set; get; }
    }
}
