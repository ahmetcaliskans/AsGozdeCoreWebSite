using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PersonnelDefinitionManager : IPersonnelDefinitionService
    {
        private IPersonnelDefinitionDal _personnelDefinitionDal;
        public PersonnelDefinitionManager(IPersonnelDefinitionDal personnelDefinitionDal)
        {
            _personnelDefinitionDal = personnelDefinitionDal;
        }

        [ValidationAspect(typeof(PersonnelDefinitionValidator))]
        public IResult Add(PersonnelDefinition personnelDefinition)
        {
            IResult result = BusinessRules.Run(CheckIfPersonnelDefinitionNameExists(personnelDefinition.Id, personnelDefinition.Name, personnelDefinition.Surname, personnelDefinition.IdentityNo));
            if (result != null)
                return result;

            _personnelDefinitionDal.Add(personnelDefinition);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(PersonnelDefinition personnelDefinition)
        {
            _personnelDefinitionDal.Delete(personnelDefinition);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<PersonnelDefinition> GetById(int personnelDefinitionId)
        {
            return new SuccessDataResult<PersonnelDefinition>(_personnelDefinitionDal.Get(p => p.Id == personnelDefinitionId));
        }

        public IDataResult<List<PersonnelDefinition>> GetList()
        {
            return new SuccessDataResult<List<PersonnelDefinition>>(_personnelDefinitionDal.GetList().ToList());
        }

        [ValidationAspect(typeof(PersonnelDefinitionValidator))]
        public IResult Update(PersonnelDefinition personnelDefinition)
        {
            IResult result = BusinessRules.Run(CheckIfPersonnelDefinitionNameExists(personnelDefinition.Id, personnelDefinition.Name, personnelDefinition.Surname, personnelDefinition.IdentityNo));
            if (result != null)
                return result;

            _personnelDefinitionDal.Update(personnelDefinition);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<PersonnelDefinition>> GetListByOfficeId(int officeId)
        {
            return new SuccessDataResult<List<PersonnelDefinition>>(_personnelDefinitionDal.GetList(x=>x.OfficeId == officeId).ToList());
        }

        public IDataResult<List<PersonnelDefinition>> GetListWithDetails(int officeId)
        {
            return new SuccessDataResult<List<PersonnelDefinition>>(_personnelDefinitionDal.GetListWithDetailsByOfficeId(officeId));
        }

        public IDataResult<PersonnelDefinition> GetByIdWithDetails(int personnelDefinitionId)
        {
            return new SuccessDataResult<PersonnelDefinition>(_personnelDefinitionDal.GetByIdWithDetails(personnelDefinitionId));
        }

        private IResult CheckIfPersonnelDefinitionNameExists(int Id, string personnelDefinitionName, string personnelDefinitionSurname, string personnelDefinitionIdentityNo)
        {
            var result = _personnelDefinitionDal.GetList(x => x.Id != Id && x.Name == personnelDefinitionName && x.Surname == personnelDefinitionSurname && x.IdentityNo == personnelDefinitionIdentityNo).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }

        
    }
}
