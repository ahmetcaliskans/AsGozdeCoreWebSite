using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IExpenseDal : IEntityRepository<Expense>
    {
        List<sp_GetListOfExpenseByOfficeId> GetListWithDetailsByOfficeId(int officeId);
        Expense GetByIdWithDetails(int expenseId);
        string GetLastDocumentNo(string shortYear);
    }
}

