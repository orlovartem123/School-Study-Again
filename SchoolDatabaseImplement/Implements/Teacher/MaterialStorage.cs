using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.Interfaces.Teacher;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using SchoolDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolDatabaseImplement.Implements.Teacher
{
    public class MaterialStorage : IMaterialStorage
    {
        public void Delete(MaterialBindingModel model)
        {
            throw new NotImplementedException();
        }

        public MaterialViewModel GetElement(MaterialBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new SchoolDbContext())
            {
                var material = context.Materials.Include(rec => rec.ElectiveMaterials)
                .ThenInclude(rec => rec.Elective)
                .FirstOrDefault(rec => rec.Id == model.Id);
                return material != null ?
                CreateModel(material) : null;
            }
        }

        public List<MaterialViewModel> GetFilteredList(MaterialBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new SchoolDbContext())
            {
                return context.Materials.Include(rec => rec.ElectiveMaterials).ThenInclude(rec=>rec.Elective)
                    .Where(rec => (!model.DateFrom.HasValue &&
                    !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
                    (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >=
                    model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
                    (model.TeacherId.HasValue && rec.TeacherId == model.TeacherId))
                    .Select(CreateModel).ToList();
            }
        }

        public List<MaterialViewModel> GetFullList()
        {
            using (var context = new SchoolDbContext())
            {
                return context.Materials
                .Include(rec => rec.ElectiveMaterials)
                .ThenInclude(rec => rec.Elective).ToList()
                .Select(CreateModel).ToList();
            }
        }

        public void Insert(MaterialBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(MaterialBindingModel model)
        {
            throw new NotImplementedException();
        }

        private MaterialViewModel CreateModel(Material material)
        {
            return new MaterialViewModel
            {
                Id = material.Id,
                Name = material.Name,
                Price = material.Price,
                MaterialElectives = material.ElectiveMaterials
                .ToDictionary(recME => recME.ElectiveId, recME =>
                (recME.Elective?.Name, recME.MaterialCount))
            };
        }

        private Material CreateModel(MaterialBindingModel model, Material car)
        {
            //car.CarName = model.CarName;
            //car.Price = model.Price;
            return car;
        }
    }
}
