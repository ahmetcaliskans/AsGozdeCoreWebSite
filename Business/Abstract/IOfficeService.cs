using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOfficeService
    {
        IDataResult<Office> GetById(int officeId);
        IDataResult<List<Office>> GetList();
        IResult Add(Office office);
        IResult Update(Office office);
        IResult Delete(Office office);
    }
}
