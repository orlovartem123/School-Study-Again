using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.ViewModels.StudentModels;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;

namespace SchoolStudyAgain.Controllers
{
    public class MaterialController : Controller
    {
        public MaterialController()
        {
        }

        public IActionResult List()
        {
            if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View(APIClient.GetRequest<List<MaterialViewModel>>($"api/teacher/getmaterials?teacherId={Program.Teacher.Id}"));
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            ViewBag.Electives = APIClient.GetRequest<List<ElectiveViewModel>>($"api/teacher/GetElectives?teacherId={Program.Teacher.Id}");
            ViewBag.Interests = APIClient.GetRequest<List<InterestViewModel>>($"api/student/GetInterestList");
            return View();
        }

        [HttpPost]
        public void Create(MaterialBindingModel model)
        {
            if (Program.Teacher == null) {  Redirect("~/Home/Enter"); }
            model.TeacherId = Program.Teacher.Id;
            model.DateCreate = DateTime.Now;
            if (model.Price == 0)
            {
                model.Price = 1;
            }
            APIClient.PostRequest("api/teacher/CreateOrUpdateMaterial", model);
            Response.Redirect("List");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            ViewBag.Interests = APIClient.GetRequest<List<InterestViewModel>>($"api/student/GetInterestList");
            ViewBag.Electives = APIClient.GetRequest<List<ElectiveViewModel>>($"api/teacher/GetElectives?teacherId={Program.Teacher.Id}");
            return View(APIClient.GetRequest<MaterialViewModel>($"api/teacher/getmaterial?materialId={id}"));
        }

        [HttpPost]
        public RedirectToActionResult Update(MaterialBindingModel material)
        {
            material.TeacherId = Program.Teacher.Id;
            APIClient.PostRequest("api/teacher/CreateOrUpdateMaterial", material);
            return RedirectToAction("List", "Material");
        }

        public void Delete(int materialId)
        {
            if (Program.Teacher == null) {  Redirect("~/Home/Enter"); }
            APIClient.PostRequest("api/teacher/DeleteMaterial", new MaterialBindingModel { Id = materialId });
            Response.Redirect("List");
        }

        [HttpGet]
        public JsonResult GetElectives()
        {
            if (Program.Teacher == null) {  Redirect("~/Home/Enter"); }
            return Json(APIClient.GetRequest<List<ElectiveViewModel>>($"api/teacher/GetElectives?teacherId={Program.Teacher.Id}"));
        }
    }
}
