using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.Interfaces.Teacher;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.BusinessLogic.TeacherLogics
{
    public class MedalLogic
    {
        private readonly IMedalStorage _medalStorage;

        public MedalLogic(IMedalStorage medalStorage)
        {
            _medalStorage = medalStorage;
        }

        public List<MedalViewModel> Read(MedalBindingModel model)
        {
            if (model == null)
            {
                return _medalStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<MedalViewModel> { _medalStorage.GetElement(model) };
            }
            return _medalStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(MedalBindingModel model)
        {
            var element = _medalStorage.GetElement(new MedalBindingModel
            {
                Name = model.Name
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("There is already a medal with the same name");
            }
            if (model.Id.HasValue)
            {
                _medalStorage.Update(model);
            }
            else
            {
                _medalStorage.Insert(model);
            }
        }

        public void Delete(MedalBindingModel model)
        {
            var element = _medalStorage.GetElement(new MedalBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Medal not found");
            }
            _medalStorage.Delete(model);
        }
    }
}
