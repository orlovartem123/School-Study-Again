using SQLite;

namespace MobileClient.Models.SqlLite
{
    [Table("AppLocalProps")]
    public class AppLocalProps
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public bool Login { get; set; }

        public string AuthToken { get; set; }

        public string TeacherId { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }
    }
}
