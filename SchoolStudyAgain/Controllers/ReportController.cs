using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.Report;
using SchoolBusinessLogic.HelperModels.Pdf;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System.Collections.Generic;

namespace SchoolStudyAgain.Controllers
{
    public class ReportController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        public ReportController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {
            ViewBag.Materials = APIClient.GetRequest<List<MaterialViewModel>>($"api/teacher/GetMaterials?teacherId={Program.Teacher.Id}");
            return View();
        }

        public IActionResult PdfReport()
        {
            return View();
        }


        [HttpPost]
        public IActionResult MakeReportWord(List<int> selectedMaterials)
        {
            var toSave = @"..\SchoolStudyAgain\wwwroot\Reports\ActivityList.doc";
            APIClient.PostRequest("api/report/SaveToWord", new ReportBindingModel { Filename = toSave, SelectedMaterials = selectedMaterials });

            var fileName = "ActivityList.doc";
            var filePath = _environment.WebRootPath + @"\Reports\" + fileName;
            return PhysicalFile(filePath, "application/doc", fileName);
        }

        [HttpPost]
        public IActionResult MakeReportXls(List<int> selectedMaterials)
        {
            var toSave = @"..\SchoolStudyAgain\wwwroot\Reports\ActivityList.xls";
            APIClient.PostRequest("api/report/SaveToExcel", new ReportBindingModel { Filename = toSave, SelectedMaterials = selectedMaterials });

            var fileName = "ActivityList.xls";
            var filePath = _environment.WebRootPath + @"\Reports\" + fileName;
            return PhysicalFile(filePath, "application/xls", fileName);
        }

        [HttpPost]
        public IActionResult MakeReportPdf(PdfReportBindingModel model)
        {
            model.FileName = @"..\SchoolStudyAgain\wwwroot\Reports\ElectivesList.pdf";
            model.TeacherName = Program.Teacher?.Name;
            APIClient.PostRequest("api/report/SaveToPdf", model);
            ViewBag.CheckingReport = model.FileName;
            return View("PdfReport");
        }

        [HttpPost]
        public IActionResult SendMail(PdfReportBindingModel model)
        {
            model.FileName = @"..\SchoolStudyAgain\wwwroot\Reports\ElectivesList.pdf";
            model.TeacherName = Program.Teacher?.Name;
            APIClient.PostRequest("api/report/SaveToPdf", model);
            MailLogic.MailSendAsync(new MailSendInfo
            {
                MailAddress = Program.Teacher?.Email,
                Subject = "Report",
                Text = "Electives report",
                ReportFile = model.FileName
            });
            return RedirectToAction("PdfReport");
        }
    }
}
