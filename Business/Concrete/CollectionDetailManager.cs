using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CollectionDetailManager : ICollectionDetailService
    {
        private ICollectionDetailDal _collectionDetailDal;

        public CollectionDetailManager(ICollectionDetailDal collectionDetailDal)
        {
            _collectionDetailDal = collectionDetailDal;
        }

        public IDataResult<CollectionDetail> GetById(int collectionDetailId)
        {
            return new SuccessDataResult<CollectionDetail>(_collectionDetailDal.Get(p => p.Id == collectionDetailId));
        }

        public IResult Add(CollectionDetail collectionDetail)
        {
            _collectionDetailDal.Add(collectionDetail);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CollectionDetail collectionDetail)
        {
            _collectionDetailDal.Delete(collectionDetail);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(CollectionDetail collectionDetail)
        {
            _collectionDetailDal.Update(collectionDetail);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<CollectionDetail>> GetListWithDetailsByCollectionId(int collectionId)
        {
            return new SuccessDataResult<List<CollectionDetail>>(_collectionDetailDal.GetListWithDetailsByCollectionId(collectionId));
        }

        public IDataResult<CollectionDetail> GetByIdWithDetails(int collectionDetailId)
        {
            return new SuccessDataResult<CollectionDetail>(_collectionDetailDal.GetByIdWithDetails(collectionDetailId));
        }
    }
}
