using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.BusinessLogic.StudentLogics;
using SchoolBusinessLogic.ViewModels.StudentModels;
using System.Collections.Generic;
using System.Linq;

namespace SchoolRestApi.Controllers
{
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
        public List<ActivityViewModel> GetActivityList(int studentId) => _activity.Read(new ActivityBindingModel { StudentId = studentId })?.ToList();

        [HttpGet]
        public ActivityViewModel GetActivity(int activityId) => _activity.Read(new ActivityBindingModel { Id = activityId })?[0];

        [HttpPost]
        public void CreateActivity(ActivityBindingModel model) => _activity.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateActivity(ActivityBindingModel model) => _activity.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteActivity(ActivityBindingModel model) => _activity.Delete(model);

        #endregion

        #region Interest

        [HttpGet]
        public List<InterestViewModel> GetInterestList() => _interest.Read(null)?.ToList();

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
