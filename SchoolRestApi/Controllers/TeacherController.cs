using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.BusinessLogic.TeacherLogics;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly MaterialLogic _material;

        private readonly ElectiveLogic _elective;

        private readonly MedalLogic _medal;

        public TeacherController(MaterialLogic material, ElectiveLogic elective, MedalLogic medal)
        {
            _material = material;
            _elective = elective;
            _medal = medal;
        }

        #region Materials

        [HttpGet]
        public string Ping() => "Ok";

        [HttpGet]
        public List<MaterialViewModel> GetMaterials() => _material.Read(null)?.ToList();

        [HttpGet]
        public MaterialViewModel GetMaterial(int materialId) => _material.Read(new MaterialBindingModel { Id = materialId })?[0];

        [HttpPost]
        public void CreateMaterial(MaterialBindingModel model) => _material.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateMaterial(MaterialBindingModel model) => _material.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteMaterial(MaterialBindingModel model) => _material.Delete(model);

        #endregion

        #region Electives

        [HttpGet]
        public List<ElectiveViewModel> GetElectives() => _elective.Read(null)?.ToList();

        //[HttpGet]
        //public List<ElectiveViewModel> GetElectives(int teacherId) => _elective.Read(new ElectiveBindingModel { TeacherId = teacherId })?.ToList();

        [HttpGet]
        public ElectiveViewModel GetElective(int electiveId) => _elective.Read(new ElectiveBindingModel { Id = electiveId })?[0];

        [HttpPost]
        public void CreateElective(ElectiveBindingModel model) => _elective.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateElective(ElectiveBindingModel model) => _elective.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteElective(ElectiveBindingModel model) => _elective.Delete(model);

        #endregion

        #region Medals

        [HttpGet]
        public List<MedalViewModel> GetMedals() => _medal.Read(null)?.ToList();

        //[HttpGet]
        //public List<MedalViewModel> GetMedals(int teacherId) => _medal.Read(new MedalBindingModel { TeacherId = teacherId })?.ToList();

        [HttpGet]
        public MedalViewModel GetMedal(int medalId) => _medal.Read(new MedalBindingModel { Id = medalId })?[0];

        [HttpPost]
        public void CreateMedal(MedalBindingModel model) => _medal.CreateOrUpdate(model);

        [HttpPost]
        public void UpdateMedal(MedalBindingModel model) => _medal.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteMedal(MedalBindingModel model) => _medal.Delete(model);

        #endregion
    }
}
