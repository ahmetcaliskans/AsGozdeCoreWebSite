using Business.Abstract;
using Business.BusinessAspects.Autofac;
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

        [RoleOperation("Collection.Show")]
        public IDataResult<CollectionDetail> GetById(int collectionDetailId)
        {
            return new SuccessDataResult<CollectionDetail>(_collectionDetailDal.Get(p => p.Id == collectionDetailId));
        }

        [RoleOperation("Collection.Insert")]
        public IResult Add(CollectionDetail collectionDetail)
        {
            _collectionDetailDal.Add(collectionDetail);
            return new SuccessResult(Messages.Added);
        }

        [RoleOperation("Collection.Delete")]
        public IResult Delete(CollectionDetail collectionDetail)
        {
            _collectionDetailDal.Delete(collectionDetail);
            return new SuccessResult(Messages.Deleted);
        }

        [RoleOperation("Collection.Update")]
        public IResult Update(CollectionDetail collectionDetail)
        {
            _collectionDetailDal.Update(collectionDetail);
            return new SuccessResult(Messages.Updated);
        }

        [RoleOperation("Collection.Show")]
        public IDataResult<List<CollectionDetail>> GetListWithDetailsByCollectionId(int collectionId)
        {
            return new SuccessDataResult<List<CollectionDetail>>(_collectionDetailDal.GetListWithDetailsByCollectionId(collectionId));
        }

        [RoleOperation("Collection.Show")]
        public IDataResult<CollectionDetail> GetByIdWithDetails(int collectionDetailId)
        {
            return new SuccessDataResult<CollectionDetail>(_collectionDetailDal.GetByIdWithDetails(collectionDetailId));
        }

        [RoleOperation("Collection.Show")]
        public IDataResult<List<CollectionDetail>> GetListWithDetailsByDriverInformationId(int driverInformationId)
        {
            return new SuccessDataResult<List<CollectionDetail>>(_collectionDetailDal.GetListWithDetailsByDriverInformationId(driverInformationId));
        }
    }
}
