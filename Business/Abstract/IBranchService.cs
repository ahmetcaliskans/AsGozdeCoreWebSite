using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBranchService
    {
        IDataResult<Branch> GetById(int branchId);
        IDataResult<List<Branch>> GetList();
        IResult Add(Branch branch);
        IResult Update(Branch branch);
        IResult Delete(Branch branch);

    }
}
