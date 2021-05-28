using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.Interfaces.Diagram;
using SchoolBusinessLogic.ViewModels.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiagramController : Controller
    {
        private readonly IDiagramDataStorage _diagramDataStorage;
        public DiagramController(IDiagramDataStorage diagramDataStorage)
        {
            _diagramDataStorage = diagramDataStorage;
        }

        [HttpGet]
        public List<DiagramDataViewModel> GetDiagramData() => _diagramDataStorage.GetMostPopularMaterials();
    }
}
