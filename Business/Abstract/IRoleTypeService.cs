using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRoleTypeService
    {
        IDataResult<RoleType> GetById(int roleTypeId);
        IDataResult<RoleType> GetByName(string roleTypeName);
        IDataResult<List<RoleType>> GetList();
        IResult Add(RoleType roleType);
        IResult Update(RoleType roleType);
        IResult Delete(RoleType roleType);
    }
}
