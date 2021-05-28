using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System.Collections.Generic;

namespace SchoolStudyAgain.Controllers
{
    public class MedalController : Controller
    {
        public MedalController()
        {
        }

        public IActionResult Create()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            ViewBag.Electives = APIClient.GetRequest<List<ElectiveViewModel>>($"api/teacher/GetElectives?teacherId={Program.Teacher.Id}");
            return View();
        }

        [HttpPost]
        public void Create(MedalBindingModel model)
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            model.TeacherId = Program.Teacher.Id;
            APIClient.PostRequest("api/teacher/CreateOrUpdateMedal", model);
            Response.Redirect("List");
        }

        [HttpGet]
        public IActionResult Update(int medalId)
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            var model = APIClient.GetRequest<MedalViewModel>($"api/teacher/GetMedal?medalId={medalId}");
            model.Id = medalId;
            ViewBag.Electives = APIClient.GetRequest<List<ElectiveViewModel>>($"api/teacher/GetElectives?teacherId={Program.Teacher.Id}");
            return View(model);
        }

        [HttpPost]
        public void Update(MedalBindingModel model)
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            if (model.ElectiveId == -1) { model.ElectiveId = null; }
            APIClient.PostRequest("api/teacher/CreateOrUpdateMedal", model);
            Response.Redirect("List");
        }

        public void Delete(int medalId)
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            APIClient.PostRequest("api/teacher/DeleteMedal", new MedalBindingModel { Id = medalId });
            Response.Redirect("List");
        }

        public IActionResult List()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            var model = APIClient.GetRequest<List<MedalViewModel>>($"api/teacher/GetMedals?teacherId={Program.Teacher.Id}");
            return View(model);
        }
    }
}
