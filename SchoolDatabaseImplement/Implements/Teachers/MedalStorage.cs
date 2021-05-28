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
    public class MedalStorage : IMedalStorage
    {
        public void Delete(MedalBindingModel model)
        {
            using (var context = new SchoolDbContext())
            {
                var element = context.Medals.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Medals.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Medal not found");
                }
            }
        }

        public MedalViewModel GetElement(MedalBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new SchoolDbContext())
            {
                var medal = context.Medals
                .Include(rec => rec.Elective)
                .FirstOrDefault(rec => rec.Name == model.Name || rec.Id == model.Id);
                return medal != null ?
                CreateModel(medal) : null;
            }
        }

        public List<MedalViewModel> GetFilteredList(MedalBindingModel model)
        {
            using (var context = new SchoolDbContext())
            {
                return context.Medals.Where(rec =>
                    (model.TeacherId.HasValue && rec.TeacherId == model.TeacherId))
                    .Include(rec => rec.Elective)
                    .Select(CreateModel).ToList();
            }
        }

        public List<MedalViewModel> GetFullList()
        {
            using (var context = new SchoolDbContext())
            {
                return context.Medals
                .Include(rec => rec.Elective)
                .Select(CreateModel).ToList();
            }
        }

        public void Insert(MedalBindingModel model)
        {
            using (var context = new SchoolDbContext())
            {
                context.Medals.Add(CreateModel(model));
                context.SaveChanges();
            }
        }

        public void Update(MedalBindingModel model)
        {
            using (var context = new SchoolDbContext())
            {
                var element = context.Medals.FirstOrDefault(rec => rec.Id == model.Id);
                element.Name = model.Name;
                element.Value = model.Value;
                element.ElectiveId = model.ElectiveId == -1 ? null : model.ElectiveId;
                context.SaveChanges();
            }
        }

        private MedalViewModel CreateModel(Medal medal)
        {
            var result = new MedalViewModel
            {
                Id = medal.Id,
                Name = medal.Name,
                Value = medal.Value
            };
            if (medal.ElectiveId == -1)
            {
                result.ElectiveId = null;
            }
            else
            {
                result.ElectiveId = medal.ElectiveId;
                result.ElectiveName = medal.Elective?.Name;
            }
            return result;
        }

        private Medal CreateModel(MedalBindingModel model)
        {
            return new Medal
            {
                Name = model.Name,
                TeacherId = (int)model.TeacherId,
                Value = model.Value,
                ElectiveId = model.ElectiveId == -1 ? null : model.ElectiveId
            };
        }
    }
}
