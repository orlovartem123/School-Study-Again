using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.BusinessLogic.StudentLogics;
using SchoolBusinessLogic.ViewModels.StudentModels;
using SchoolStudyAgain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SchoolStudyAgainApi.Controllers
{
    [Authorize(Roles = "admin,teacher,student")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ActivityLogic _activity;

        private readonly InterestLogic _interest;

        public StudentController(ActivityLogic activity, InterestLogic interest)
        {
            _activity = activity;
            _interest = interest;
        }

        #region Activity

        [HttpGet]
        public List<ActivityViewModel> GetActivityList() => _activity.Read(null)?.ToList();

        [HttpGet]
        public ActivityViewModel GetActivity(int activityId) => _activity.Read(new ActivityBindingModel { Id = activityId })?[0];

        [HttpPost]
        public void CreateOrUpdateActivity(ActivityBindingModel model) => _activity.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteActivity(ActivityBindingModel model) => _activity.Delete(model);

        #endregion

        #region Interest

        [HttpGet]
        public CustomHttpResponse GetInterests()
        {
            try
            {
                var result = new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Data = _interest.Read(null)
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
        public InterestViewModel GetInterest(int interestId) => _interest.Read(new InterestBindingModel())?[0];

        [HttpPost]
        public void CreateInterest(InterestBindingModel model) => _interest.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateInterest(InterestBindingModel model) => _interest.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteInterest(InterestBindingModel model) => _interest.Delete(model);

        #endregion      
    }
}
