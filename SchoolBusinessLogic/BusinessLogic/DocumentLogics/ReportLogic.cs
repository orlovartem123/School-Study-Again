using SchoolBusinessLogic.BindingModels.Report;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.HelperModels.Excel;
using SchoolBusinessLogic.HelperModels.Pdf;
using SchoolBusinessLogic.HelperModels.Word;
using SchoolBusinessLogic.Interfaces.Student;
using SchoolBusinessLogic.Interfaces.Teacher;
using SchoolBusinessLogic.ViewModels.StudentModels;
using System.Collections.Generic;

namespace SchoolBusinessLogic.BusinessLogic.DocumentLogics
{
    public class ReportLogic
    {
        private readonly IActivityStorage _activityStorage;
        private readonly IElectiveStorage _electiveStorage;

        public ReportLogic(IActivityStorage activityStorage, IElectiveStorage electiveStorage)
        {
            _activityStorage = activityStorage;
            _electiveStorage = electiveStorage;
        }

        public List<ActivityViewModel> GetActivityByMaterials(List<int> selectedMaterials)
        {
            var electiveIdList = new List<int>();
            foreach (var el in _electiveStorage.GetFullList())
            {
                if (el.ElectiveMaterials == null)
                {
                    continue;
                }
                foreach (var key in el.ElectiveMaterials.Keys)
                {
                    if (selectedMaterials.Contains(key))
                    {
                        electiveIdList.Add(el.Id);
                        break;
                    }
                }
            }
            var result = new List<ActivityViewModel>();
            foreach (var el in _activityStorage.GetFullList())
            {
                if (el.ActivityElectives == null)
                {
                    continue;
                }
                foreach (var key in el.ActivityElectives.Keys)
                {
                    if (electiveIdList.Contains(key))
                    {
                        result.Add(el);
                        break;
                    }
                }
            }
            return result;
        }

        public void SaveToWordFile(List<int> selectedMaterials, string filename)
        {
            SaveToWord.CreateDoc(new ExlelInfo
            {
                FileName = filename,
                Title = "Activity list",
                Activities = GetActivityByMaterials(selectedMaterials)
            });
        }

        public void SaveToExcelFile(List<int> selectedMaterials, string filename)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = filename,
                Title = "Activity list",
                Activities = GetActivityByMaterials(selectedMaterials)
            });
        }

        [System.Obsolete]
        public void SaveToPdfFile(PdfReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                TeacherName = model.TeacherName,
                Title = "Electives list",
                DateFrom = model.DateFrom,
                DateTo = model.DateTo,
                Electives = _electiveStorage.GetFilteredList(new ElectiveBindingModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
            });
        }
    }
}
