using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.BusinessLogic.TeacherLogics;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using SchoolStudyAgain.Interface;
using System;

namespace SchoolStudyAgainApi.Controllers
{
    [Authorize(Roles = "admin,teacher")]
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
        public CustomHttpResponse GetInfoByExtId(string extId)
        {
            try
            {
                var result = new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Data = _logic.GetByExtId(extId)
                };
                return result;
            }
            catch (Exception ex)
            {
                return new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Errors = new string[] { ex.Message }
                };
            }
        }

        [HttpGet]
        public TeacherViewModel Login(string login, string password, string email) => _logic.Read(new TeacherBindingModel { Login = login, Password = password, Email = email })?[0];

        [HttpPost]
        public CustomHttpResponse CreateTeacher(TeacherBindingModel model)
        {
            try
            {
                var result = _logic.CreateWithResult(model);
                return new CustomHttpResponse { StatusCode = System.Net.HttpStatusCode.OK, Data = result };
            }
            catch (Exception ex)
            {
                return new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Errors = new string[] { ex.Message }
                };
            }
        }

        [HttpPost]
        public void Register(TeacherBindingModel model) => _logic.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateData(TeacherBindingModel model) => _logic.CreateOrUpdate(model);
    }
}
