using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICollectionDefinitionAmountDal : IEntityRepository<CollectionDefinitionAmount>
    {
        List<CollectionDefinitionAmount> GetListWithDetails();
    }
}
