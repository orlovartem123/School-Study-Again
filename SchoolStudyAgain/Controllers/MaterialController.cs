using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.ViewModels.StudentModels;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System.Collections.Generic;
using System.Linq;

namespace SchoolStudyAgain.Controllers
{
    public class MaterialController : Controller
    {
        public MaterialController()
        {
        }

        public IActionResult Create()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            ViewBag.Electives = APIClient.GetRequest<List<ElectiveViewModel>>($"api/teacher/GetElectives?teacherId={Program.Teacher.Id}");
            ViewBag.Interests = APIClient.GetRequest<List<InterestViewModel>>($"api/student/GetInterestList");
            return View();
        }

        [HttpPost]
        public void Create(MaterialBindingModel model)
        {
            model.TeacherId = Program.Teacher.Id;
            APIClient.PostRequest("api/teacher/CreateOrUpdateMaterial", model);
            Response.Redirect("List");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View(APIClient.GetRequest<MaterialViewModel>($"api/teacher/getmaterial?materialId={id}"));
        }

        [HttpPost]
        public void Update(MaterialBindingModel material)
        {
            material.TeacherId = Program.Teacher.Id;
            APIClient.PostRequest("api/teacher/CreateOrUpdateMaterial", material);
            Response.Redirect("List");
        }

        public IActionResult Delete()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View();
        }

        public IActionResult List()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View(APIClient.GetRequest<List<MaterialViewModel>>($"api/teacher/getmaterials?teacherId={Program.Teacher.Id}"));
        }

        [HttpGet]
        public List<ElectiveViewModel> GetElectives()
        {
            return APIClient.GetRequest<List<ElectiveViewModel>>($"api/teacher/GetElectives?teacherId={Program.Teacher.Id}");
        }
    }
}
