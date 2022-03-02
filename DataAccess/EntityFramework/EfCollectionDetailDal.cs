using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfCollectionDetailDal : EfEntityRepositoryBase<CollectionDetail, AsGozdeWebSiteDB>, ICollectionDetailDal
    {
        public CollectionDetail GetByIdWithDetails(int collectionDetailId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.CollectionDetails.Include(x => x.PaymentType).Include(x => x.CollectionDefinition).Where(x => x.Id == collectionDetailId);
                return result.FirstOrDefault();
            }
        }

        List<CollectionDetail> ICollectionDetailDal.GetListWithDetailsByCollectionId(int collectionId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.CollectionDetails.Include(x => x.PaymentType).Include(x => x.CollectionDefinition).Where(x => x.CollectionId== collectionId);
                return result.ToList();
            }
        }
    }
}
