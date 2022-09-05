using Core.Entities.Abstract;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface Isp_GetRoleService
    {
        IDataResult<List<sp_GetRole>> GetRolesByRoleTypeId(int roleTypeId);

        IDataResult<sp_GetRole> GetRoleByRoleTypeIdAndRoleFormDefinitionId(int roleTypeId, int roleFormDefinitionId);
    }
}
