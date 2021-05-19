using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.TeacherModels;

namespace SchoolStudyAgain.Controllers
{
    public class ElectiveController : Controller
    {
        public ElectiveController()
        {
        }

        public IActionResult CreateElective()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateElective(int id)
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View(/*APIClient.GetRequest<ElectiveViewModel>($"api/teacher/getelective?electiveId={id}")*/);
        }

        [HttpPost]
        public void UpdateElective(ElectiveBindingModel elective)
        {
            //APIClient.PostRequest("api/teacher/updateelective", elective);
            Response.Redirect("ElectiveList");
        }

        public IActionResult DeleteElective()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View();
        }

        public IActionResult ElectiveList()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View(/*APIClient.GetRequest<List<ElectiveViewModel>>($"api/teacher/getelectives")*/);
        }
    }
}
