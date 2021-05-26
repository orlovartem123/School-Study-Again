using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.Interfaces.Teacher;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using SchoolDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDatabaseImplement.Implements.Teacher
{
    public class MaterialStorage : IMaterialStorage
    {
        public void Delete(MaterialBindingModel model)
        {
            using (var context = new SchoolDbContext())
            {
                var element = context.Materials.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Materials.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Element not found");
                }
            }
        }

        public MaterialViewModel GetElement(MaterialBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new SchoolDbContext())
            {
                var material = context.Materials
                .Include(rec => rec.ElectiveMaterials)
                .ThenInclude(rec => rec.Elective)
                .Include(rec => rec.MaterialInterests)
                .ThenInclude(rec => rec.Interest)
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
                return context.Materials
                    .Include(rec => rec.ElectiveMaterials)
                    .ThenInclude(rec => rec.Elective)
                    .Include(rec => rec.MaterialInterests)
                    .ThenInclude(rec => rec.Interest)
                    .Where(rec =>
                    (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >=
                    model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
                    model.TeacherId.HasValue && rec.TeacherId == model.TeacherId)
                    .Select(CreateModel).ToList();
            }
        }

        public List<MaterialViewModel> GetFullList()
        {
            using (var context = new SchoolDbContext())
            {
                return context.Materials
                .Include(rec => rec.ElectiveMaterials)
                .ThenInclude(rec => rec.Elective)
                .Include(rec => rec.MaterialInterests)
                .ThenInclude(rec => rec.Interest).ToList()
                .Select(CreateModel).ToList();
            }
        }

        public void Insert(MaterialBindingModel model)
        {
            if (model != null)
            {
                using (var context = new SchoolDbContext())
                {
                    context.Materials.Add(CreateModel(model));
                    context.SaveChanges();
                    var newId = context.Materials.FirstOrDefault(rec => rec.Name == model.Name).Id;
                    if (model.InterestIds != null)
                    {
                        context.MaterialInterests.AddRange(InsertMaterialInterests(model, newId));
                    }
                    if (model.ElectiveMaterials != null)
                    {
                        context.ElectiveMaterials.AddRange(InsertElectiveMaterials(model, newId));
                    }
                    context.SaveChanges();
                }
            }
        }

        public void Update(MaterialBindingModel model)
        {
            if (model != null)
            {
                using (var context = new SchoolDbContext())
                {
                    var element = context.Materials.Include(rec => rec.MaterialInterests).FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Elem not found");
                    }
                    element.Name = model.Name;
                    element.Price = model.Price;

                    var toRemove = context.MaterialInterests.Where(rec => rec.MaterialId == model.Id);
                    context.MaterialInterests.RemoveRange(toRemove);
                    //context.MaterialInterests.AddRange(CreateModels(model));
                    context.Materials.Add(CreateModel(model));
                    context.SaveChanges();
                }
            }
        }

        private MaterialViewModel CreateModel(Material material)
        {
            return new MaterialViewModel
            {
                Id = material.Id,
                Name = material.Name,
                Price = material.Price,
                DateCreate = material.DateCreate,
                Interests = material.MaterialInterests.Select(rec => (rec.InterestId, rec.Interest.Name)).ToList(),
                MaterialElectives = material.ElectiveMaterials
                .ToDictionary(recME => recME.ElectiveId, recME =>
                (recME.Elective?.Name, recME.MaterialCount))
            };
        }

        private Material CreateModel(MaterialBindingModel model)
        {
            return new Material
            {
                Name = model.Name,
                Price = model.Price,
                TeacherId = (int)model.TeacherId,
                DateCreate = model.DateCreate
            };
        }

        private List<MaterialInterest> InsertMaterialInterests(MaterialBindingModel model, int newId)
        {
            var result = new List<MaterialInterest>();
            foreach (var el in model.InterestIds)
            {
                result.Add(new MaterialInterest
                {
                    MaterialId = newId,
                    InterestId = el
                });
            }
            return result;
        }

        private List<ElectiveMaterial> InsertElectiveMaterials(MaterialBindingModel model, int newId)
        {
            var result = new List<ElectiveMaterial>();
            foreach (var el in model.ElectiveMaterials)
            {
                result.Add(new ElectiveMaterial
                {
                    ElectiveId = el.Key,
                    MaterialId = newId,
                    MaterialCount = el.Value
                });
            }
            return result;
        }
    }
}
