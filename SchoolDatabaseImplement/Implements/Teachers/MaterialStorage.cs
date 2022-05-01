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
        private readonly SchoolDbContext context;

        public MaterialStorage(SchoolDbContext db)
        {
            context = db;
        }

        public void Delete(MaterialBindingModel model)
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

        public void DeleteMany(IList<int> ids)
        {
            var forDel = context.Materials.Where(x => ids.Contains(x.Id)).ToArray();

            if (forDel.Length > 0)
            {
                context.Materials.RemoveRange(forDel);
                context.SaveChanges();
            }
        }

        public MaterialViewModel GetElement(MaterialBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var material = context.Materials
            .Include(rec => rec.ElectiveMaterials)
            .ThenInclude(rec => rec.Elective)
            .Include(rec => rec.MaterialInterests)
            .ThenInclude(rec => rec.Interest)
            .FirstOrDefault(rec => rec.Id == model.Id);
            return material != null ?
            CreateModel(material) : null;
        }

        public List<MaterialViewModel> GetFilteredList(MaterialBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return context.Materials
                .Include(rec => rec.ElectiveMaterials)
                .ThenInclude(rec => rec.Elective)
                .Include(rec => rec.MaterialInterests)
                .ThenInclude(rec => rec.Interest)
                .Where(rec =>
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >=
                model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
                model.TeacherId != null && rec.TeacherId == model.TeacherId)
                .Select(CreateModel).ToList();
        }

        public List<MaterialViewModel> GetFullList()
        {
            return context.Materials
            .Include(rec => rec.ElectiveMaterials)
            .ThenInclude(rec => rec.Elective)
            .Include(rec => rec.MaterialInterests)
            .ThenInclude(rec => rec.Interest).ToList()
            .Select(CreateModel).ToList();
        }

        public void Insert(MaterialBindingModel model)
        {
            if (model != null)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Materials.Add(CreateModel(model));
                        context.SaveChanges();
                        var newId = context.Materials.FirstOrDefault(rec => rec.Name == model.Name).Id;
                        context.MaterialInterests.AddRange(InsertMaterialInterests(model, newId));
                        context.ElectiveMaterials.AddRange(InsertElectiveMaterials(model, newId));
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        public void Update(MaterialBindingModel model)
        {
            if (model != null)
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Materials
                        .Include(rec => rec.MaterialInterests)
                        .Include(rec => rec.ElectiveMaterials)
                        .FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Elem not found");
                        }
                        element.Name = model.Name;
                        element.Price = model.Price;
                        var interestsToRm = context.MaterialInterests.Where(rec => rec.MaterialId == model.Id);
                        context.MaterialInterests.RemoveRange(interestsToRm);
                        context.SaveChanges();
                        var electviesToRm = context.ElectiveMaterials.Where(rec => rec.MaterialId == model.Id);
                        context.ElectiveMaterials.RemoveRange(electviesToRm);
                        context.SaveChanges();
                        context.MaterialInterests.AddRange(InsertMaterialInterests(model, (int)model.Id));
                        context.ElectiveMaterials.AddRange(InsertElectiveMaterials(model, (int)model.Id));
                        var material = context.Materials.FirstOrDefault(rec => rec.Id == model.Id);
                        UpdateMaterial(material, model);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
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
                Interests = material.MaterialInterests.Select(rec => Tuple.Create(rec.InterestId, rec.Interest.Name)).ToList(),
                MaterialElectives = material.ElectiveMaterials
                .ToDictionary(recME => recME.ElectiveId, recME =>
                Tuple.Create(recME.Elective?.Name, recME.MaterialCount))
            };
        }

        private Material CreateModel(MaterialBindingModel model)
        {
            return new Material
            {
                Name = model.Name,
                Price = model.Price,
                DateCreate = model.DateCreate,
                TeacherId = model.TeacherId.Value
            };
        }

        private void UpdateMaterial(Material material, MaterialBindingModel model)
        {
            material.Name = model.Name;
            material.Price = model.Price;
        }

        private List<MaterialInterest> InsertMaterialInterests(MaterialBindingModel model, int id)
        {
            var result = new List<MaterialInterest>();
            if (model.InterestIds == null)
            {
                return result;
            }
            foreach (var el in model.InterestIds)
            {
                result.Add(new MaterialInterest
                {
                    MaterialId = id,
                    InterestId = el
                });
            }
            return result;
        }

        private List<ElectiveMaterial> InsertElectiveMaterials(MaterialBindingModel model, int id)
        {
            var result = new List<ElectiveMaterial>();
            if (model.ElectiveMaterials == null)
            {
                return result;
            }
            foreach (var el in model.ElectiveMaterials)
            {
                result.Add(new ElectiveMaterial
                {
                    ElectiveId = el.Key,
                    MaterialId = id,
                    MaterialCount = el.Value
                });
            }
            return result;
        }
    }
}
