using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.TeacherModels;

namespace SchoolStudyAgain.Controllers
{
    public class MedalController : Controller
    {
        public MedalController()
        {
        }

        public IActionResult CreateMedal()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateMedal(int id)
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View(/*APIClient.GetRequest<MedalViewModel>($"api/teacher/getmedal?medalId={id}")*/);
        }

        [HttpPost]
        public void UpdateMedal(MedalBindingModel medal)
        {
            //APIClient.PostRequest("api/teacher/updatemedal", medal);
            Response.Redirect("MedalList");
        }

        public IActionResult DeleteMedal()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View();
        }

        public IActionResult MedalList()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View(/*APIClient.GetRequest<List<MedalViewModel>>($"api/teacher/getmedals?teacherId={3}")*/);
        }
    }
}
