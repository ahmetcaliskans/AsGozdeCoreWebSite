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
    public class Efsp_GetListOfDueCoursePaymentDal : EfDtoRepositoryBase<sp_GetListOfDueCoursePayment, AsGozdeWebSiteDB>, Isp_GetListOfDueCoursePaymentDal
    {
        public List<sp_GetListOfDueCoursePayment> GetList(DateTime dueDate, int officeId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Sp_GetListOfDueCoursePayments.FromSqlRaw("sp_GetListOfDueCoursePayments @p0,@p1",dueDate.Date,officeId);
                return result.ToList();
            }
        }
    }
}
