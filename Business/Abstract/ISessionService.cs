using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISessionService
    {
        IDataResult<Session> GetById(int SessionId);
        IDataResult<List<Session>> GetList();
        IResult Add(Session Session);
        IResult Update(Session Session);
        IResult Delete(Session Session);
    }
}
