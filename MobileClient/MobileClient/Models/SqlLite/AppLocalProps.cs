using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
