using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RoleFormDefinitionManager : IRoleFormDefinitionService
    {

        IRoleFormDefinitionDal _roleFormDefinitionDal;

        public RoleFormDefinitionManager(IRoleFormDefinitionDal roleFormDefinitionDal)
        {
            _roleFormDefinitionDal = roleFormDefinitionDal;
        }

        [RoleOperation("RoleFormDefinition.Show")]
        public IDataResult<RoleFormDefinition> GetById(int roleFormDefinitionId)
        {
            return new SuccessDataResult<RoleFormDefinition>(_roleFormDefinitionDal.Get(p => p.Id == roleFormDefinitionId));
        }

        [RoleOperation("RoleFormDefinition.Show")]
        public IDataResult<List<RoleFormDefinition>> GetList()
        {
            return new SuccessDataResult<List<RoleFormDefinition>>(_roleFormDefinitionDal.GetList().ToList());
        }

        [RoleOperation("RoleFormDefinition.Show")]
        //[ValidationAspect(typeof(RoleDefinitionValidator))]
        public IResult Add(RoleFormDefinition roleFormDefinition)
        {
            IResult result = BusinessRules.Run(CheckIfSessionNameExists(roleFormDefinition.Id, roleFormDefinition.FormName, roleFormDefinition.FormSubName));
            if (result != null)
                return result;

            _roleFormDefinitionDal.Add(roleFormDefinition);
            return new SuccessResult(Messages.Added);
        }

        [RoleOperation("RoleFormDefinition.Update")]
        //[ValidationAspect(typeof(RoleDefinitionValidator))]
        public IResult Update(RoleFormDefinition roleFormDefinition)
        {
            IResult result = BusinessRules.Run(CheckIfSessionNameExists(roleFormDefinition.Id,roleFormDefinition.FormName, roleFormDefinition.FormSubName));
            if (result != null)
                return result;

            _roleFormDefinitionDal.Update(roleFormDefinition);
            return new SuccessResult(Messages.Updated);
        }

        [RoleOperation("RoleFormDefinition.Delete")]
        public IResult Delete(RoleFormDefinition roleFormDefinition)
        {
            _roleFormDefinitionDal.Delete(roleFormDefinition);
            return new SuccessResult(Messages.Deleted);
        }

        private IResult CheckIfSessionNameExists(int Id, string roleFormName, string roleFormSubName)
        {
            var result = _roleFormDefinitionDal.GetList(x => x.Id != Id && x.FormName == roleFormName && x.FormSubName == roleFormSubName).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }

    }
}
