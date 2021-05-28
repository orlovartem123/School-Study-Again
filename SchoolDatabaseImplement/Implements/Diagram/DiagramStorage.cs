using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.Interfaces.Diagram;
using SchoolBusinessLogic.ViewModels.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolDatabaseImplement.Implements.Diagram
{
    public class DiagramStorage : IDiagramDataStorage
    {
        public List<DiagramDataViewModel> GetMostPopularMaterials()
        {
            using (var context = new SchoolDbContext())
            {
                var result = new List<DiagramDataViewModel>();
                result.Add(new DiagramDataViewModel());
                result[0].Title = "Most popular materials";
                result[0].Data = new Dictionary<string, int>();
                foreach (var record in context.ElectiveMaterials.Include(rec => rec.Material))
                {
                    if (result[0].Data.ContainsKey(record.Material.Name))
                    {
                        result[0].Data[record.Material.Name] += record.MaterialCount;
                    }
                    else
                    {
                        result[0].Data.Add(record.Material.Name, record.MaterialCount);
                    }
                }
                Console.WriteLine(result[0].Title);
                return result;
            }
        }
    }
}
