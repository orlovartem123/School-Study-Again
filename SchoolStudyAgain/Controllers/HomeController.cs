using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using SchoolStudyAgain.Models;
using System;
using System.Diagnostics;

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

        [HttpPost]
        public void Enter(string login, string password,string email)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                Program.Teacher = APIClient.GetRequest<TeacherViewModel>($"api/TeacherAccount/login?login={login}&password={password}&email={email}");
                if (Program.Teacher == null)
                {
                    throw new Exception("Invalid username / password");
                }
                Response.Redirect("../Material/List");
                return;
            }
            throw new Exception("Enter login, password");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public void Register(string password, string name, string position,string surname,string login,string email)
        {
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(name))
            {
                APIClient.PostRequest("api/TeacherAccount/register", new TeacherBindingModel
                {
                    Name = name,
                    Email = email,
                    Password = password,
                    Position = position,
                    Surname=surname,
                    Login=login
                });
                Response.Redirect("Enter");
                return;
            }
            throw new Exception("Enter login, password and full name");
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
