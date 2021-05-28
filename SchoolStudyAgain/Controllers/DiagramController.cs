using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.ViewModels.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolStudyAgain.Controllers
{
    public class DiagramController : Controller
    {
        public DiagramController()
        {
        }

        public IActionResult MostPopularMaterial()
        {
            var model = APIClient.GetRequest<List<DiagramDataViewModel>>($"api/diagram/GetDiagramData");
            return View(model);
        }
    }
}
