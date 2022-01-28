using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.Report;
using SchoolBusinessLogic.BusinessLogic.DocumentLogics;
using System.Collections.Generic;

namespace SchoolStudyAgainApi.Controllers
{
    [Authorize(Roles = "admin,teacher,student")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly ReportLogic _reportLogic;

        public ReportController(ReportLogic reportLogic)
        {
            _reportLogic = reportLogic;
        }

        [HttpPost]
        public void SaveToWord(ReportBindingModel model) => _reportLogic.SaveToWordFile(model.SelectedMaterials, model.Filename);

        [HttpPost]
        public void SaveToExcel(ReportBindingModel model) => _reportLogic.SaveToExcelFile(model.SelectedMaterials, model.Filename);

        [HttpPost]
        [System.Obsolete]
        public void SaveToPdf(PdfReportBindingModel model)
        {
            _reportLogic.SaveToPdfFile(model);
        }
    }
}
