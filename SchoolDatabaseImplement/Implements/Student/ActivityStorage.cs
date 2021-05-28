using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.Interfaces.Student;
using SchoolBusinessLogic.ViewModels.StudentModels;
using SchoolDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDatabaseImplement.Implements.Student
{
    public class ActivityStorage : IActivityStorage
    {
        public void Delete(ActivityBindingModel model)
        {
            throw new NotImplementedException();
        }

        public ActivityViewModel GetElement(ActivityBindingModel model)
        {
            using (var context = new SchoolDbContext())
            {
                var el = context.Activities.Include(rec => rec.ActivityElectives)
                .ThenInclude(rec => rec.Elective).ToList().FirstOrDefault(rec => rec.Id == model.Id);
                return CreateModel(el);
            }
        }

        public List<ActivityViewModel> GetFilteredList(ActivityBindingModel model)
        {
            throw new NotImplementedException();
        }


        public List<ActivityViewModel> GetFullList()
        {
            using (var context = new SchoolDbContext())
            {
                return context.Activities
                .Include(rec => rec.ActivityElectives)
                .ThenInclude(rec => rec.Elective).ToList()
                .Select(CreateModel)?.ToList();
            }
        }

        public void Insert(ActivityBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(ActivityBindingModel model)
        {
            throw new NotImplementedException();
        }

        private ActivityViewModel CreateModel(Activity activity)
        {
            return new ActivityViewModel
            {
                Id = activity.Id,
                Name = activity.Name,
                ActivityElectives = activity.ActivityElectives
                .ToDictionary(recME => recME.ElectiveId, recME =>
                recME.Elective?.Name)
            };
        }
    }
}
