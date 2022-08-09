using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRoleService
    {
        IDataResult<Role> GetById(int roleId);
        IDataResult<List<Role>> GetList();
        IDataResult<List<Role>> GetListByRoleType(int roleTypeId);
        IResult Add(Role role);
        IResult Update(Role role);
        IResult Delete(Role role);
    }
}
