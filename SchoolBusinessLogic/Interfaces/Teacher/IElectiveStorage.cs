﻿using SchoolBusinessLogic.BindingModels.TeacherModels;
using SchoolBusinessLogic.ViewModels.TeacherModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBusinessLogic.Interfaces.Teacher
{
    public interface IElectiveStorage
    {
        List<ElectiveViewModel> GetFullList();
        List<ElectiveViewModel> GetFilteredList(ElectiveBindingModel model);
        ElectiveViewModel GetElement(ElectiveBindingModel model);
        void Insert(ElectiveBindingModel model);
        void Update(ElectiveBindingModel model);
        void Delete(ElectiveBindingModel model);
    }
}