using SchoolBusinessLogic.BindingModels.StudentModels;
using SchoolBusinessLogic.Interfaces.Student;
using SchoolBusinessLogic.ViewModels.StudentModels;
using System;
using System.Collections.Generic;

namespace SchoolBusinessLogic.BusinessLogic.StudentLogics
{
    public class InterestLogic
    {
        private readonly IInterestStorage _interestStorage;

        public InterestLogic(IInterestStorage interestStorage)
        {
            _interestStorage = interestStorage;
        }

        public List<InterestViewModel> Read(InterestBindingModel model)
        {
            return _interestStorage.GetFullList();
        }

        public void CreateOrUpdate(InterestBindingModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(InterestBindingModel model)
        {
            throw new NotImplementedException();
        }
    }
}
