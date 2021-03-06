using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.BusinessLogic.TeacherLogics;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System.Collections.Generic;
using System.Linq;

namespace SchoolRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly MaterialLogic _material;

        private readonly ElectiveLogic _elective;

        private readonly MedalLogic _medal;

        private readonly int onPage = 30;

        public TeacherController(MaterialLogic material, ElectiveLogic elective, MedalLogic medal)
        {
            _material = material;
            _elective = elective;
            _medal = medal;
        }

        #region Materials

        [HttpGet]
        public List<MaterialViewModel> GetMaterials(int teacherId) => _material.Read(new MaterialBindingModel { TeacherId = teacherId })?.ToList();

        [HttpGet]
        public MaterialViewModel GetMaterial(int materialId) => _material.Read(new MaterialBindingModel { Id = materialId })?[0];

        [HttpGet]
        public List<MaterialViewModel> GetMaterialPaging(int teacherId, int page) => _material.Read(new MaterialBindingModel { TeacherId = teacherId, ToTake = onPage, ToSkip = (page - 1) * onPage }).ToList();

        [HttpPost]
        public void CreateOrUpdateMaterial(MaterialBindingModel model) => _material.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteMaterial(MaterialBindingModel model) => _material.Delete(model);

        #endregion

        #region Electives

        [HttpGet]
        public List<ElectiveViewModel> GetElectives(int teacherId) => _elective.Read(new ElectiveBindingModel { TeacherId = teacherId })?.ToList();

        [HttpGet]
        public ElectiveViewModel GetElective(int electiveId) => _elective.Read(new ElectiveBindingModel { Id = electiveId })?[0];

        [HttpPost]
        public void CreateOrUpdateElective(ElectiveBindingModel model) => _elective.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteElective(ElectiveBindingModel model) => _elective.Delete(model);

        [HttpPost]
        public void BindActivityWithElectives(BindActivityWithElectivesBindingModel model) => _elective.BindActivityWithElectives(model);

        #endregion

        #region Medals

        [HttpGet]
        public List<MedalViewModel> GetMedals(int teacherId) => _medal.Read(new MedalBindingModel { TeacherId = teacherId })?.ToList();

        [HttpGet]
        public MedalViewModel GetMedal(int medalId) => _medal.Read(new MedalBindingModel { Id = medalId })?[0];

        [HttpPost]
        public void CreateOrUpdateMedal(MedalBindingModel model) => _medal.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteMedal(MedalBindingModel model) => _medal.Delete(model);

        #endregion
    }
}
