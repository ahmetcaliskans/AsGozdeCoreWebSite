using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetByUserName(string userCode);
        IDataResult<List<UserForRegisterDto>> GetListWithDetails();
        IDataResult<User> GetById(int SessionId);
        IDataResult<List<User>> GetList();
        IResult Add(User Session);
        IResult Update(User Session);
        IResult Delete(User Session);
    }
}
