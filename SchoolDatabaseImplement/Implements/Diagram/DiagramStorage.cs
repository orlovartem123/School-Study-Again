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
        private readonly SchoolDbContext context;

        public DiagramStorage(SchoolDbContext db)
        {
            context = db;
        }

        public List<DiagramDataViewModel> GetMostPopularMaterials()
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
            result.Add(new DiagramDataViewModel());
            result[1].Title = "Most popular electives";
            result[1].Data = new Dictionary<string, int>();
            foreach (var record in context.Electives.Include(rec => rec.ActivityElectives))
            {
                result[1].Data.Add(record.Name, record.ActivityElectives.Count);
            }
            result.Add(new DiagramDataViewModel());
            result[2].Title = "Material price rating";
            result[2].DataPrice = new Dictionary<string, decimal>();
            result[2].ValueName = "Cost";
            result[2].ColumnName = "Material name";
            foreach (var record in context.Materials)
            {
                result[2].DataPrice.Add(record.Name, record.Price);
            }
            return result;

        }
    }
}
