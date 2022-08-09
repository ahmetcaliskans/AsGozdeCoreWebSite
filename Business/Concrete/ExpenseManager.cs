using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ExpenseManager : IExpenseService
    {
        private IExpenseDal _expenseDal;
        public ExpenseManager(IExpenseDal expenseDal)
        {
            _expenseDal = expenseDal;
        }

        [ValidationAspect(typeof(ExpenseValidator))]
        public IResult Add(Expense expense)
        {
            _expenseDal.Add(expense);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Expense expense)
        {
            _expenseDal.Delete(expense);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Expense> GetById(int expenseId)
        {
            return new SuccessDataResult<Expense>(_expenseDal.Get(p => p.Id == expenseId));
        }

        public IDataResult<Expense> GetByIdWithDetails(int expenseId)
        {
            return new SuccessDataResult<Expense>(_expenseDal.GetByIdWithDetails(expenseId));
        }

        public IDataResult<string> GetLastDocumentNo(string shortYear)
        {
            return new SuccessDataResult<string>(_expenseDal.GetLastDocumentNo(shortYear));
        }

        public IDataResult<List<sp_GetListOfExpenseByOfficeId>> GetListWithDetailsByOfficeId(int officeId)
        {
            return new SuccessDataResult<List<sp_GetListOfExpenseByOfficeId>>(_expenseDal.GetListWithDetailsByOfficeId(officeId));
        }

        [ValidationAspect(typeof(ExpenseValidator))]
        public IResult Update(Expense expense)
        {
            _expenseDal.Update(expense);
            return new SuccessResult(Messages.Added);
        }
    }
}
