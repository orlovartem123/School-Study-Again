﻿using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolStudyAgain.Controllers
{
    public class MaterialController : Controller
    {
        public MaterialController()
        {
        }

        public IActionResult CreateMaterial()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateMaterial(int id)
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View(APIClient.GetRequest<MaterialViewModel>($"api/teacher/getmaterial?materialId={id}"));
        }

        [HttpPost]
        public void UpdateMaterial(MaterialBindingModel material)
        {
            APIClient.PostRequest("api/teacher/updatematerial", material);
            Response.Redirect("MaterialList");
        }

        public IActionResult DeleteMaterial()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View();
        }

        public IActionResult MaterialList()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View(APIClient.GetRequest<List<MaterialViewModel>>($"api/teacher/getmaterials?teacherId={3}"));
        }
    }
}