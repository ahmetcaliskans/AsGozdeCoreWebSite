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
    public class EfReportDal : EfDtoRepositoryBase<sp_rCashReport1, AsGozdeWebSiteDB>, IReportDal
    {
        public List<sp_rCashReport1> sp_rCashReport1GetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int collecitonDefinitionId, int collectionDefinitionTypeId,
            int sessionId, int branchId, int expenseDefinitionId, int fixtureDefinitionId, int personnelDefinitionId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Sp_rCashReport1s.FromSqlRaw("sp_rCashReport1 @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10", officeId, startDate, endDate, paymentTypeId, collecitonDefinitionId, collectionDefinitionTypeId,
                    sessionId, branchId, expenseDefinitionId, fixtureDefinitionId, personnelDefinitionId);
                return result.ToList();
            }
        }

        public List<sp_rCashReport1DetailCollection> sp_rCashReport1DetailCollectionGetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int collecitonDefinitionId, int collectionDefinitionTypeId,
           int sessionId, int branchId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Sp_rCashReport1DetailCollections.FromSqlRaw("sp_rCashReport1DetailCollection @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7", officeId, startDate, endDate, paymentTypeId, collecitonDefinitionId, collectionDefinitionTypeId,
                    sessionId, branchId);
                return result.ToList();
            }
        }

        public List<sp_rCashReport1DetailExpense> sp_rCashReport1DetailExpenseGetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int expenseDefinitionId, int fixtureDefinitionId, 
            int personnelDefinitionId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Sp_rCashReport1DetailExpenses.FromSqlRaw("sp_rCashReport1DetailExpense @p0,@p1,@p2,@p3,@p4,@p5,@p6", officeId, startDate, endDate, paymentTypeId, expenseDefinitionId, fixtureDefinitionId,
                    personnelDefinitionId);
                return result.ToList();
            }
        }
    }
}

