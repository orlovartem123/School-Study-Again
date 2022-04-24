using System;
using System.Collections.Generic;
using System.Text;

namespace MobileClient.Models.Electives
{
    public class Elective
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime DateCreate { get; set; }

        public Dictionary<int, (string, int)> ElectiveMaterials { get; set; }

        public Dictionary<int, string> ElectiveActivities { get; set; }
    }
}
