using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRoleFormDefinitionService
    {
        IDataResult<RoleFormDefinition> GetById(int roleFormDefinitionId);
        IDataResult<List<RoleFormDefinition>> GetList();
        IResult Add(RoleFormDefinition roleFormDefinition);
        IResult Update(RoleFormDefinition roleFormDefinition);
        IResult Delete(RoleFormDefinition roleFormDefinition);
    }
}
