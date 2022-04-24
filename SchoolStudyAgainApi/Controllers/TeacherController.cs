using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.BusinessLogic.TeacherLogics;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using SchoolStudyAgain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolStudyAgainApi.Controllers
{
    [Authorize(Roles = "admin,teacher")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly MaterialLogic _material;

        private readonly ElectiveLogic _elective;

        private readonly MedalLogic _medal;

        private readonly int onPage = 130;

        public TeacherController(MaterialLogic material, ElectiveLogic elective, MedalLogic medal)
        {
            _material = material;
            _elective = elective;
            _medal = medal;
        }

        [HttpGet]
        public async Task<CustomHttpResponse> Ping()
        {
            return new CustomHttpResponse { StatusCode = System.Net.HttpStatusCode.OK, Data = "Pong" };
        }

        #region Materials

        [HttpGet]
        public List<MaterialViewModel> GetMaterials(int teacherId) => _material.Read(new MaterialBindingModel { TeacherId = teacherId })?.ToList();

        [HttpGet]
        public MaterialViewModel GetMaterial(int materialId) => _material.Read(new MaterialBindingModel { Id = materialId })?[0];

        [HttpGet]
        public List<MaterialViewModel> GetMaterialPaging(int teacherId, int page = 1) => _material.Read(new MaterialBindingModel { TeacherId = teacherId, ToTake = onPage, ToSkip = (page - 1) * onPage }).ToList();

        [HttpPost]
        public void CreateOrUpdateMaterial(MaterialBindingModel model) => _material.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteMaterial(MaterialBindingModel model) => _material.Delete(model);

        #endregion

        #region Electives

        [HttpGet]
        public CustomHttpResponse GetElectives(int teacherId)
        {
            try
            {
                var result = new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Data = _elective.Read(new ElectiveBindingModel { TeacherId = teacherId })
                };
                return result;
            }
            catch (Exception ex)
            {
                return new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Errors = new string[] { ex.Message }
                };
            }
        }

        [HttpGet]
        public CustomHttpResponse GetElective(int electiveId)
        {
            try
            {
                var result = new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Data = _elective.Read(new ElectiveBindingModel { Id = electiveId })?[0]
                };
                return result;
            }
            catch (Exception ex)
            {
                return new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Errors = new string[] { ex.Message }
                };
            }
        }

        [HttpPost]
        public CustomHttpResponse CreateOrUpdateElective(ElectiveBindingModel model)
        {
            try
            {
                _elective.CreateOrUpdate(model);
                var result = new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };
                return result;
            }
            catch (Exception ex)
            {
                return new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Errors = new string[] { ex.Message }
                };
            }
        }

        [HttpPost]
        public CustomHttpResponse DeleteElective(ElectiveBindingModel model)
        {
            try
            {
                _elective.Delete(model);
                var result = new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };
                return result;
            }
            catch (Exception ex)
            {
                return new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Errors = new string[] { ex.Message }
                };
            }
        }

        [HttpPost]
        public CustomHttpResponse BindActivityWithElectives(BindActivityWithElectivesBindingModel model)
        {
            try
            {
                _elective.BindActivityWithElectives(model);
                var result = new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };
                return result;
            }
            catch (Exception ex)
            {
                return new CustomHttpResponse
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Errors = new string[] { ex.Message }
                };
            }
        }

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
