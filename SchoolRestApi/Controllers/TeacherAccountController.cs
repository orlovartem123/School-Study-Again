using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.BusinessLogic.TeacherLogics;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherAccountController : ControllerBase
    {
        private readonly TeacherLogic _logic;

        public TeacherAccountController(TeacherLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public TeacherViewModel Login(string login, string password) => _logic.Read(new TeacherBindingModel { Login = login, Password = password })?[0];

        [HttpPost]
        public void Register(TeacherBindingModel model) => _logic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(TeacherBindingModel model) => _logic.CreateOrUpdate(model);
    }
}
