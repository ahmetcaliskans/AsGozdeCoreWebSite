using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICollectionDetailDal : IEntityRepository<CollectionDetail>
    {
        List<CollectionDetail> GetListWithDetailsByCollectionId(int collectionId);
        CollectionDetail GetByIdWithDetails(int collectionDetailId);
    }
}
