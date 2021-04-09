using Microsoft.EntityFrameworkCore;
using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.Interfaces.Student;
using SchoolBusinessLogic.ViewModels.StudentModels;
using SchoolDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            throw new NotImplementedException();
        }

        public List<ActivityViewModel> GetFilteredList(ActivityBindingModel model)
        {
            using (var context = new SchoolDbContext())
            {
                if (model.Electives != null && model.Electives.Count > 0)
                {
                    var result = new List<ActivityViewModel>();
                    foreach (var activity in context.Activities.Include(rec => rec.ActivityElectives))
                    {
                        foreach (var electiveId in model.Electives)
                        {
                            if (activity.ActivityElectives.Select(rec => rec.ElectiveId).Contains(electiveId.Key))
                            {
                                result.Add(CreateModel(activity));
                                break;
                            }
                        }
                    }
                    return result;
                }
                //return context.Electives
                //.Include(rec => rec.ElectiveMaterials)
                //.ThenInclude(rec => rec.Elective).Where(rec =>
                //    (model.TeacherId.HasValue && rec.TeacherId == model.TeacherId))
                //    .Select(CreateModel).ToList();
                return null;
            }
        }

        public List<ActivityViewModel> GetFullList()
        {
            using (var context = new SchoolDbContext())
            {
                return context.Activities
                .Include(rec => rec.ActivityElectives)
                .ThenInclude(rec => rec.Elective).ToList()
                .Select(CreateModel).ToList();
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
