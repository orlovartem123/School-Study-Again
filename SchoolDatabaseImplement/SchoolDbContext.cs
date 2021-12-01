using Microsoft.EntityFrameworkCore;
using SchoolDatabaseImplement.Models;

namespace SchoolDatabaseImplement
{
    public class SchoolDbContext : DbContext
    {
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

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

    }
}
