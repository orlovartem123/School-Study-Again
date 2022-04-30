using System;
using System.Collections.Generic;

namespace MobileClient.DataContracts
{
    public class MaterialContract
    {
        public int? Id { get; set; }

        public int? TeacherId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public int? ToSkip { get; set; }

        public int? ToTake { get; set; }

        public List<int> InterestIds { get; set; }

        public Dictionary<int, int> ElectiveMaterials { get; set; }
    }
}
