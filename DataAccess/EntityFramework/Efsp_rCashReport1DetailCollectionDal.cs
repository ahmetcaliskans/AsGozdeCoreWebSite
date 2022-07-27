using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class Efsp_rCashReport1DetailCollectionDal : EfDtoRepositoryBase<sp_rCashReport1DetailCollection, AsGozdeWebSiteDB>, Isp_rCashReport1DetailCollectionDal
    {
        public List<sp_rCashReport1DetailCollection> GetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int collecitonDefinitionId, int collectionDefinitionTypeId,
            int sessionId, int branchId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                //var StartDate = new SqlParameter("StartDate", startDate.Date);
                //StartDate.DbType = System.Data.DbType.Date;
                //var EndDate = new SqlParameter("EndDate", endDate.Date);
                //EndDate.DbType = System.Data.DbType.Date;
                var result = context.Sp_rCashReport1DetailCollections.FromSqlRaw("sp_rCashReport1DetailCollection @p0,@p1,@p2,@p3,@p4,@p5,@p6,@p7", officeId, startDate, endDate, paymentTypeId, collecitonDefinitionId, collectionDefinitionTypeId,
                    sessionId, branchId);
                return result.ToList();
            }
        }
    }
}


