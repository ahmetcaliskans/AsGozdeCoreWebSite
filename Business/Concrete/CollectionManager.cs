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
    public class CollectionManager : ICollectionService
    {
        private ICollectionDal _collectionDal;

        public CollectionManager(ICollectionDal collectionDal)
        {
            _collectionDal = collectionDal;
        }

        public IDataResult<Collection> GetById(int collectionId)
        {
            return new SuccessDataResult<Collection>(_collectionDal.Get(p => p.Id == collectionId));
        }

        public IResult Add(Collection collection)
        {
            _collectionDal.Add(collection);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Collection collection)
        {
            _collectionDal.Delete(collection);
            return new SuccessResult(Messages.Deleted);
        }

        public IResult Update(Collection collection)
        {
            _collectionDal.Update(collection);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<Collection>> GetListWithDetailsByOfficeId(int officeId)
        {
            return new SuccessDataResult<List<Collection>>(_collectionDal.GetListWithDetailsByOfficeId(officeId));
        }

        public IDataResult<Collection> GetByIdWithDetails(int collectionId)
        {
            return new SuccessDataResult<Collection>(_collectionDal.GetByIdWithDetails(collectionId));
        }

        public IDataResult<string> GetLastDocumentNo(int shortYear)
        {
            return new SuccessDataResult<string>(_collectionDal.GetLastDocumentNo(shortYear));
        }
    }
}
