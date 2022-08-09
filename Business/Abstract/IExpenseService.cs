using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IExpenseService
    {
        IDataResult<Expense> GetById(int expenseId);
        IDataResult<Expense> GetByIdWithDetails(int expenseId);
        IDataResult<List<sp_GetListOfExpenseByOfficeId>> GetListWithDetailsByOfficeId(int officeId);
        IDataResult<string> GetLastDocumentNo(string shortYear);
        IResult Add(Expense expense);
        IResult Update(Expense expense);
        IResult Delete(Expense expense);
    }
}
