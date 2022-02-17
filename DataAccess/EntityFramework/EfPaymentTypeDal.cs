using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfPaymentTypeDal : EfEntityRepositoryBase<PaymentType,AsGozdeWebSiteDB>, IPaymentTypeDal
    {

    }
}
