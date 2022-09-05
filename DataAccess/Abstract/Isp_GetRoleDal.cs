using Core.DataAccess;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface Isp_GetRoleDal : IDtoRepository<sp_GetRole>
    {
        List<sp_GetRole> GetRolesByRoleTypeId(int roleTypeId);
        sp_GetRole GetRoleByRoleTypeIdAndRoleFormDefinitionId(int roleTypeId, int roleFormDefinitionId);
    }
}
