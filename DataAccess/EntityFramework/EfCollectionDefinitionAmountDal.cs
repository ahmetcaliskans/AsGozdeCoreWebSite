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
    public class EfCollectionDefinitionAmountDal : EfEntityRepositoryBase<CollectionDefinitionAmount,AsGozdeWebSiteDB>, ICollectionDefinitionAmountDal
    {
        public List<CollectionDefinitionAmount> GetListWithDetails()
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.CollectionDefinitionAmounts.Include(x => x.CollectionDefinition);
                return result.ToList();
            }
        }
    }
}
