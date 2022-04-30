using System;
using System.Collections.Generic;

namespace MobileClient.Models.Materials
{
    public class Material
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public List<(int, string)> Interests { get; set; }

        public Dictionary<int, (string, int)> MaterialElectives { get; set; }

        public DateTime DateCreate { get; set; }
    }
}
