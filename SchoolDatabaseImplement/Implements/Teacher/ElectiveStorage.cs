﻿using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.Interfaces.Teacher;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolDatabaseImplement.Implements.Teacher
{
    public class ElectiveStorage : IElectiveStorage
    {
        public void Delete(ElectiveBindingModel model)
        {
            using (var context = new SchoolDbContext())
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
        }

        public ElectiveViewModel GetElement(ElectiveBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new SchoolDbContext())
            {
                var elective = context.Electives
                .Include(rec => rec.ElectiveMaterials)
                .ThenInclude(rec => rec.Material)
                .Include(rec=>rec.ActivityElectives)
                .ThenInclude(rec=>rec.Activity)
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
        }

        public List<ElectiveViewModel> GetFilteredList(ElectiveBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<ElectiveViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }

        public void Insert(ElectiveBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(ElectiveBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
