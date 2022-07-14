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
    public class Efsp_GetSequentialPaymentDal : EfDtoRepositoryBase<sp_GetSequentialPayment, AsGozdeWebSiteDB>, Isp_GetSequentialPaymentDal
    {
        public List<sp_GetSequentialPayment> GetByDriverInformationIdAndCollectionDefinitionTypeId(int driverInformationId, int collectionDefinitionTypeId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Sp_GetSequentialPayments.FromSqlRaw("sp_GetSequentialPayments @p0,@p1", driverInformationId, collectionDefinitionTypeId);
                return result.ToList();
            }
        }
    }
}
