using Business.Abstract;
using Core.Entities.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class Sp_GetRoleManager : Isp_GetRoleService
    {
        private Isp_GetRoleDal _sp_GetRoleDal;
        public Sp_GetRoleManager(Isp_GetRoleDal sp_GetRoleDal)
        {
            _sp_GetRoleDal = sp_GetRoleDal;
        }

        public IDataResult<sp_GetRole> GetRoleByRoleTypeIdAndRoleFormDefinitionId(int roleTypeId, int roleFormDefinitionId)
        {
            return new SuccessDataResult<sp_GetRole>(_sp_GetRoleDal.GetRoleByRoleTypeIdAndRoleFormDefinitionId(roleTypeId, roleFormDefinitionId));
        }

        public IDataResult<List<sp_GetRole>> GetRolesByRoleTypeId(int roleTypeId)
        {
            return new SuccessDataResult<List<sp_GetRole>>(_sp_GetRoleDal.GetRolesByRoleTypeId(roleTypeId));
        }
    }
}
