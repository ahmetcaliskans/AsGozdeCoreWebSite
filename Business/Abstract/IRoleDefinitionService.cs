using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRoleDefinitionService
    {
        IDataResult<RoleDefinition> GetById(int roleDefinitionId);
        IDataResult<List<RoleDefinition>> GetList();
        IResult Add(RoleDefinition roleDefinition);
        IResult Update(RoleDefinition roleDefinition);
        IResult Delete(RoleDefinition roleDefinition);
    }
}
