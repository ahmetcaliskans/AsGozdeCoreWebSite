using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CollectionDefinitionManager : ICollectionDefinitionService
    {
        private ICollectionDefinitionDal _collectionDefinitionDal;
        public CollectionDefinitionManager(ICollectionDefinitionDal collectionDefinitionDal)
        {
            _collectionDefinitionDal = collectionDefinitionDal;
        }

        public IResult Add(CollectionDefinition collectionDefinition)
        {
            IResult result = BusinessRules.Run(CheckIfcollectionDefinitionNameExists(collectionDefinition.Id, collectionDefinition.Name, collectionDefinition.Sequence));
            if (result != null)
                return result;

            _collectionDefinitionDal.Add(collectionDefinition);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CollectionDefinition collectionDefinition)
        {
            _collectionDefinitionDal.Delete(collectionDefinition);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<CollectionDefinition> GetById(int collectionDefinitionId)
        {
            return new SuccessDataResult<CollectionDefinition>(_collectionDefinitionDal.Get(p => p.Id == collectionDefinitionId));
        }

        public IDataResult<CollectionDefinition> GetByName(string collectionDefinitionName)
        {
            return new SuccessDataResult<CollectionDefinition>(_collectionDefinitionDal.Get(p => p.Name == collectionDefinitionName));
        }

        public IDataResult<List<CollectionDefinition>> GetList()
        {
            return new SuccessDataResult<List<CollectionDefinition>>(_collectionDefinitionDal.GetList().ToList());
        }

        public IResult Update(CollectionDefinition collectionDefinition)
        {
            IResult result = BusinessRules.Run(CheckIfcollectionDefinitionNameExists(collectionDefinition.Id, collectionDefinition.Name, collectionDefinition.Sequence));
            if (result != null)
                return result;

            _collectionDefinitionDal.Update(collectionDefinition);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfcollectionDefinitionNameExists(int Id, string collectionDefinitionName, int collectionDefinitionSequence)
        {
            var result = _collectionDefinitionDal.GetList(x => x.Id != Id && x.Name == collectionDefinitionName && x.Sequence == collectionDefinitionSequence).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
