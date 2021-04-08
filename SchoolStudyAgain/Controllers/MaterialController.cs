using Microsoft.AspNetCore.Mvc;
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

        public IActionResult UpdateMaterial()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View();
        }

        public IActionResult DeleteMaterial()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View();
        }

        public IActionResult ShowMaterials()
        {
            //if (Program.Teacher == null) { return Redirect("~/Home/Enter"); }
            return View();
        }
    }
}
