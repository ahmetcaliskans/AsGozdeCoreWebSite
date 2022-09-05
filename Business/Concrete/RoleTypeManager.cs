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
    public class RoleTypeManager : IRoleTypeService
    {

        IRoleTypeDal _roleTypeDal;

        public RoleTypeManager(IRoleTypeDal roleTypeDal)
        {
            _roleTypeDal = roleTypeDal;
        }

        public IDataResult<RoleType> GetById(int roleTypeId)
        {
            return new SuccessDataResult<RoleType>(_roleTypeDal.Get(p => p.Id == roleTypeId));
        }

        public IDataResult<RoleType> GetByName(string roleTypeName)
        {
            return new SuccessDataResult<RoleType>(_roleTypeDal.Get(p => p.Name == roleTypeName));
        }

        public IDataResult<List<RoleType>> GetList()
        {
            return new SuccessDataResult<List<RoleType>>(_roleTypeDal.GetList().ToList());
        }

        [RoleOperation("RoleType.Insert")]
        //[ValidationAspect(typeof(RoleTypeValidator))]
        public IResult Add(RoleType roleType)
        {
            IResult result = BusinessRules.Run(CheckIfSessionNameExists(roleType.Id, roleType.Name));
            if (result != null)
                return result;

            _roleTypeDal.Add(roleType);
            return new SuccessResult(Messages.Added);
        }

        [RoleOperation("RoleType.Update")]
        //[ValidationAspect(typeof(RoleTypeValidator))]
        public IResult Update(RoleType roleType)
        {
            IResult result = BusinessRules.Run(CheckIfSessionNameExists(roleType.Id, roleType.Name));
            if (result != null)
                return result;

            _roleTypeDal.Update(roleType);
            return new SuccessResult(Messages.Updated);
        }

        [RoleOperation("RoleType.Delete")]
        public IResult Delete(RoleType roleType)
        {
            _roleTypeDal.Delete(roleType);
            return new SuccessResult(Messages.Deleted);
        }

        private IResult CheckIfSessionNameExists(int Id, string roleTypeName)
        {
            var result = _roleTypeDal.GetList(x => x.Id != Id && x.Name == roleTypeName).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }

    }
}
