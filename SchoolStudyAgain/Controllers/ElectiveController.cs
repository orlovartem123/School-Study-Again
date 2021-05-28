using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.ViewModels.StudentModels;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;

namespace SchoolStudyAgain.Controllers
{
    public class ElectiveController : Controller
    {
        public ElectiveController()
        {
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create(ElectiveBindingModel model)
        {
            if (Program.Teacher == null) { Redirect("~/Home/Enter"); }
            model.TeacherId = Program.Teacher.Id;
            model.DateCreate = DateTime.Now;
            APIClient.PostRequest("api/teacher/CreateOrUpdateElective", model);
            Response.Redirect("List");
        }

        [HttpGet]
        public IActionResult Update(int electiveId)
        {
            if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            var model = APIClient.GetRequest<ElectiveViewModel>($"api/teacher/getelective?electiveId={electiveId}");
            model.Id = electiveId;
            return View(model);
        }

        [HttpPost]
        public void Update(ElectiveBindingModel model)
        {
            if (Program.Teacher == null) {  Redirect("~/Home/Enter"); }
            APIClient.PostRequest("api/teacher/CreateOrUpdateElective", model);
            Response.Redirect("List");
        }

        public void Delete(int electiveId)
        {
            if (Program.Teacher == null) {  Redirect("~/Home/Enter"); }
            APIClient.PostRequest("api/teacher/DeleteElective", new ElectiveBindingModel { Id = electiveId });
            Response.Redirect("List");
        }

        public IActionResult List()
        {
            if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View(APIClient.GetRequest<List<ElectiveViewModel>>($"api/teacher/getelectives?teacherId={Program.Teacher.Id}"));
        }

        public IActionResult BindActivityWithElectives()
        {
            if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            ViewBag.Activities = APIClient.GetRequest<List<ActivityViewModel>>($"api/student/GetActivityList");
            ViewBag.Electives = APIClient.GetRequest<List<ActivityViewModel>>($"api/teacher/GetElectives?teacherId={Program.Teacher.Id}");
            return View();
        }

        [HttpPost]
        public void BindActivityWithElectives(BindActivityWithElectivesBindingModel model)
        {
            if (Program.Teacher == null) { Redirect("~/Home/Enter"); }
            APIClient.PostRequest("api/teacher/BindActivityWithElectives", model);
            Response.Redirect("List");
        }
    }
}
