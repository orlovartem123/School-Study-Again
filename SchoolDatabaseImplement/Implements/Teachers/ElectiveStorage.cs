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
    public class ElectiveStorage : IElectiveStorage
    {
        private readonly SchoolDbContext context;

        public ElectiveStorage(SchoolDbContext db)
        {
            context = db;
        }

        public void Delete(ElectiveBindingModel model)
        {
            var element = context.Electives.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Electives.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Elective not found");
            }
        }

        public ElectiveViewModel GetElement(ElectiveBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var elective = context.Electives
            .Include(rec => rec.ElectiveMaterials)
            .ThenInclude(rec => rec.Material)
            .Include(rec => rec.ActivityElectives)
            .ThenInclude(rec => rec.Activity)
            .FirstOrDefault(rec => rec.Name == model.Name || rec.Id == model.Id);
            return elective != null ?
            new ElectiveViewModel
            {
                Id = elective.Id,
                Name = elective.Name,
                Price = elective.Price,
                ElectiveMaterials = elective.ElectiveMaterials.ToDictionary(recEM => recEM.MaterialId, recEM => (recEM.Material?.Name, recEM.MaterialCount))
            } : null;
        }

        public List<ElectiveViewModel> GetFilteredList(ElectiveBindingModel model)
        {
            return context.Electives.Where(rec =>
                (model.TeacherId != null && rec.TeacherId == model.TeacherId) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo))
                .Include(rec => rec.ElectiveMaterials)
                .ThenInclude(rec => rec.Material)
                .Include(rec => rec.ActivityElectives)
                .ThenInclude(rec => rec.Activity)
                .Select(CreateModel).ToList();
        }

        public List<ElectiveViewModel> GetFullList()
        {
            return context.Electives
            .Include(rec => rec.ElectiveMaterials)
            .ThenInclude(rec => rec.Material)
            .Include(rec => rec.ActivityElectives)
            .ThenInclude(rec => rec.Activity).ToList()
            .Select(CreateModel).ToList();
        }

        public void Insert(ElectiveBindingModel model)
        {
            context.Electives.Add(CreateModel(model));
            context.SaveChanges();
        }

        public void Update(ElectiveBindingModel model)
        {
            var element = context.Electives.FirstOrDefault(rec => rec.Id == model.Id);
            element.Name = model.Name;
            element.Price = model.Price;
            context.SaveChanges();
        }

        public void BindActivityWithElectives(BindActivityWithElectivesBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var toRemove = context.ActivityElectives.Where(rec => rec.ActivityId == model.ActivityId);
                    context.ActivityElectives.RemoveRange(toRemove);
                    context.SaveChanges();
                    context.ActivityElectives.AddRange(CreateModels(model));
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }

        private ElectiveViewModel CreateModel(Elective elective)
        {
            return new ElectiveViewModel
            {
                Id = elective.Id,
                Name = elective.Name,
                Price = elective.Price,
                DateCreate = elective.DateCreate,
                ElectiveMaterials = elective.ElectiveMaterials
                .ToDictionary(recME => recME.MaterialId, recME =>
                (recME.Material?.Name, recME.MaterialCount)),
                ElectiveActivities = elective.ActivityElectives.ToDictionary(rec => rec.ActivityId, rec => rec.Activity?.Name)
            };
        }

        private Elective CreateModel(ElectiveBindingModel model)
        {
            return new Elective
            {
                Name = model.Name,
                Price = model.Price,
                TeacherId = model.TeacherId,
                DateCreate = model.DateCreate
            };
        }

        private List<ActivityElective> CreateModels(BindActivityWithElectivesBindingModel model)
        {
            var result = new List<ActivityElective>();
            foreach (var el in model.Electives)
            {
                result.Add(new ActivityElective
                {
                    ActivityId = (int)model.ActivityId,
                    ElectiveId = el
                });
            }
            return result;
        }
    }
}
