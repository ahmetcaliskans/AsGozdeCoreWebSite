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
    public class RoleManager : IRoleService
    {

        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }

        [RoleOperation("Role.Show")]
        public IDataResult<Role> GetById(int roleId)
        {
            return new SuccessDataResult<Role>(_roleDal.Get(p => p.Id == roleId));
        }

        [RoleOperation("Role.Show")]
        public IDataResult<List<Role>> GetList()
        {
            return new SuccessDataResult<List<Role>>(_roleDal.GetList().ToList());
        }

        [RoleOperation("Role.Show")]
        public IDataResult<List<Role>> GetListByRoleType(int roleTypeId)
        {
            return new SuccessDataResult<List<Role>>(_roleDal.GetList().Where(x=>x.RoleTypeId == roleTypeId).ToList());
        }

        [RoleOperation("Role.Insert")]
        //[ValidationAspect(typeof(RoleValidator))]
        public IResult Add(Role role)
        {
            IResult result = BusinessRules.Run(CheckIfSessionNameExists(role.Id, role.RoleTypeId, role.RoleFormDefinitionId));
            if (result != null)
                return result;

            _roleDal.Add(role);
            return new SuccessResult(Messages.Added);
        }

        [RoleOperation("Role.Update")]
        //[ValidationAspect(typeof(RoleValidator))]
        public IResult Update(Role role)
        {
            IResult result = BusinessRules.Run(CheckIfSessionNameExists(role.Id, role.RoleTypeId, role.RoleFormDefinitionId));
            if (result != null)
                return result;

            _roleDal.Update(role);
            return new SuccessResult(Messages.Updated);
        }

        [RoleOperation("Role.Delete")]
        public IResult Delete(Role role)
        {
            _roleDal.Delete(role);
            return new SuccessResult(Messages.Deleted);
        }

        private IResult CheckIfSessionNameExists(int Id, int roleTypeId, int roleFormDefinitionId)
        {
            var result = _roleDal.GetList(x => x.Id != Id && x.RoleTypeId == roleTypeId && x.RoleFormDefinitionId == roleFormDefinitionId).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }

    }
}
