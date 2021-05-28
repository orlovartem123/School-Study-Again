using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.Interfaces.Teacher;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolDatabaseImplement.Implements.Teacher
{
    public class TeacherStorage : ITeacherStorage
    {
        public void Delete(TeacherBindingModel model)
        {
            throw new NotImplementedException();
        }

        public TeacherViewModel GetElement(TeacherBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new SchoolDbContext())
            {
                var client = context.Teachers
                .FirstOrDefault(rec => rec.Email.Equals(model.Email) || rec.Id == model.Id);
                return client != null ?
                new TeacherViewModel { Name = client.Name, Email = client.Email, Id = client.Id, Surname = client.Surname } : null;
            }
        }

        public List<TeacherViewModel> GetFilteredList(TeacherBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new SchoolDbContext())
            {
                return context.Teachers
                    .Where(rec =>
                    rec.Name.Contains(model.Name) || (rec.Email.Equals(model.Email) && rec.Password.Equals(model.Password) && rec.Login.Equals(model.Login)))
                    .Select(rec => new TeacherViewModel { Name = rec.Name, Email = rec.Email, Id = rec.Id, Surname = rec.Surname }).ToList();
            }
        }

        public List<TeacherViewModel> GetFullList()
        {
            throw new NotImplementedException();
        }

        public void Insert(TeacherBindingModel model)
        {
            using (var context = new SchoolDbContext())
            {
                context.Teachers.Add(CreateModel(model, new Models.Teacher()));
                context.SaveChanges();
            }
        }

        public void Update(TeacherBindingModel model)
        {
            throw new NotImplementedException();
        }

        private Models.Teacher CreateModel(TeacherBindingModel model, Models.Teacher client)
        {
            client.Name = model.Name;
            client.Surname = model.Surname;
            client.Position = model.Surname;
            client.Login = model.Login;
            client.Email = model.Email;
            client.Password = model.Password;
            return client;
        }
    }
}
