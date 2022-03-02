using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICollectionDetailService
    {
        IDataResult<CollectionDetail> GetById(int collectionDetailId);
        IDataResult<CollectionDetail> GetByIdWithDetails(int collectionDetailId);
        IDataResult<List<CollectionDetail>> GetListWithDetailsByCollectionId(int collectionId);
        IResult Add(CollectionDetail collectionDetail);
        IResult Update(CollectionDetail collectionDetail);
        IResult Delete(CollectionDetail collectionDetail);
    }
}
