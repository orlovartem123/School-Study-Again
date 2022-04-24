using System;
using System.Collections.Generic;

namespace MobileClient.Models.Electives
{
    public class ElectiveBindingModel
    {
        public int? Id { get; set; }

        public int? TeacherId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public List<int> Activities { get; set; }
    }
}
