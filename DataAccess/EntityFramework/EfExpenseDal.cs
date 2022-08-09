using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfExpenseDal : EfEntityRepositoryBase<Expense, AsGozdeWebSiteDB>, IExpenseDal
    {
        public Expense GetByIdWithDetails(int expenseId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Expenses.Include(x => x.Office).Include(x => x.PaymentType).Include(x => x.ExpenseDefinition).Include(x => x.FixtureDefinition).Include(x => x.PersonnelDefinition).Where(x => x.Id == expenseId);
                if (result.Count() > 0)
                {
                    return result.FirstOrDefault();
                }
                return result.FirstOrDefault();
            }
        }

        public List<sp_GetListOfExpenseByOfficeId> GetListWithDetailsByOfficeId(int officeId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Sp_GetListOfExpenseByOfficeIds.FromSqlRaw("sp_GetListOfExpenseByOfficeId @p0", officeId);
                return result.ToList();
            }
        }

        public string GetLastDocumentNo(string shortYear)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Expenses.Where(x => x.DocumentNo.StartsWith(shortYear.ToString())).Max(x => x.DocumentNo);
                return result;
            }
        }

    }
}
