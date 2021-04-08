using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolStudyAgain.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolStudyAgain.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {          
        }

        public IActionResult Index()
        {
            if (Program.Teacher == null)
            {
                return Redirect("~/Home/Enter");
            }
            return View();
        }

        public IActionResult Enter()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
