using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.BusinessLogic.StudentLogics;
using SchoolBusinessLogic.ViewModels.StudentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentAccountController : ControllerBase
    {
        private readonly StudentLogic _logic;

        public StudentAccountController(StudentLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public StudentViewModel Login(string login, string password) => _logic.Read(new StudentBindingModel { Login = login, Password = password })?[0];

        [HttpPost]
        public void Register(StudentBindingModel model) => _logic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(StudentBindingModel model) => _logic.CreateOrUpdate(model);
    }
}
