using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ExpenseDefinitionManager : IExpenseDefinitionService
    {
        private IExpenseDefinitionDal _expenseDefinitionDal;
        public ExpenseDefinitionManager(IExpenseDefinitionDal expenseDefinitionDal)
        {
            _expenseDefinitionDal = expenseDefinitionDal;
        }

        [RoleOperation("ExpenseDefinition.Insert")]
        [ValidationAspect(typeof(ExpenseDefinitionValidator))]
        public IResult Add(ExpenseDefinition expenseDefinition)
        {
            IResult result = BusinessRules.Run(CheckIfExpenseDefinitionNameExists(expenseDefinition.Id, expenseDefinition.Name));
            if (result != null)
                return result;

            _expenseDefinitionDal.Add(expenseDefinition);
            return new SuccessResult(Messages.Added);
        }

        [RoleOperation("ExpenseDefinition.Delete")]
        public IResult Delete(ExpenseDefinition expenseDefinition)
        {
            _expenseDefinitionDal.Delete(expenseDefinition);
            return new SuccessResult(Messages.Deleted);
        }

        
        public IDataResult<ExpenseDefinition> GetById(int expenseDefinitionId)
        {
            return new SuccessDataResult<ExpenseDefinition>(_expenseDefinitionDal.Get(p => p.Id == expenseDefinitionId));
        }

        
        public IDataResult<List<ExpenseDefinition>> GetList()
        {
            return new SuccessDataResult<List<ExpenseDefinition>>(_expenseDefinitionDal.GetList().ToList());
        }

        [RoleOperation("ExpenseDefinition.Update")]
        [ValidationAspect(typeof(ExpenseDefinitionValidator))]
        public IResult Update(ExpenseDefinition expenseDefinition)
        {
            IResult result = BusinessRules.Run(CheckIfExpenseDefinitionNameExists(expenseDefinition.Id, expenseDefinition.Name));
            if (result != null)
                return result;

            _expenseDefinitionDal.Update(expenseDefinition);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfExpenseDefinitionNameExists(int Id, string expenseDefinitionName)
        {
            var result = _expenseDefinitionDal.GetList(x => x.Id != Id && x.Name == expenseDefinitionName).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
