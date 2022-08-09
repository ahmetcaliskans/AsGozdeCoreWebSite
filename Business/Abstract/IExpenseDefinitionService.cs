using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IExpenseDefinitionService
    {
        IDataResult<ExpenseDefinition> GetById(int expenseDefinitionId);
        IDataResult<List<ExpenseDefinition>> GetList();
        IResult Add(ExpenseDefinition expenseDefinition);
        IResult Update(ExpenseDefinition expenseDefinition);
        IResult Delete(ExpenseDefinition expenseDefinition);
    }
}
