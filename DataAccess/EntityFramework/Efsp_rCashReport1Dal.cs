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
    public class Efsp_rCashReport1Dal : EfDtoRepositoryBase<sp_rCashReport1, AsGozdeWebSiteDB>, Isp_rCashReport1Dal
    {
        public List<sp_rCashReport1> GetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int collecitonDefinitionId, int collectionDefinitionTypeId,
            int sessionId, int branchId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Sp_rCashReport1s.FromSqlRaw("sp_rCashReport1 @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7", officeId, startDate, endDate, paymentTypeId, collecitonDefinitionId, collectionDefinitionTypeId,
                    sessionId,branchId);
                return result.ToList();
            }
        }
    }
}

