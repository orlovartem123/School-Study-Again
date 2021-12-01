using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.Interfaces.Student;
using SchoolBusinessLogic.ViewModels.StudentModels;
using SchoolDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDatabaseImplement.Implements.Student
{
    public class InterestStorage : IInterestStorage
    {
        private readonly SchoolDbContext context;

        public InterestStorage(SchoolDbContext db)
        {
            context = db;
        }

        public void Delete(InterestBindingModel model)
        {
            throw new NotImplementedException();
        }

        public InterestViewModel GetElement(InterestBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<InterestViewModel> GetFilteredList(InterestBindingModel model)
        {
            throw new NotImplementedException();
        }

        public List<InterestViewModel> GetFullList()
        {
            return context.Interests
            .Select(CreateModel).ToList();
        }

        public void Insert(InterestBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void Update(InterestBindingModel model)
        {
            throw new NotImplementedException();
        }

        private InterestViewModel CreateModel(Interest interest)
        {
            return new InterestViewModel
            {
                Id = interest.Id,
                Name = interest.Name
            };
        }
    }
}
