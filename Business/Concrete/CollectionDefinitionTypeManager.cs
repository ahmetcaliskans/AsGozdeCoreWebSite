using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
    public class CollectionDefinitionTypeManager : ICollectionDefinitionTypeService
    {
        private ICollectionDefinitionTypeDal _collectionDefinitionTypeDal;
        public CollectionDefinitionTypeManager(ICollectionDefinitionTypeDal collectionDefinitionTypeDal)
        {
            _collectionDefinitionTypeDal = collectionDefinitionTypeDal;
        }
        
        //[ValidationAspect(typeof(CollectionDefinitionTypeValidator))]
        public IResult Add(CollectionDefinitionType collectionDefinitionType)
        {
            IResult result = BusinessRules.Run(CheckIfcollectionDefinitionTypeExists(collectionDefinitionType.Id));
            if (result != null)
                return result;

            _collectionDefinitionTypeDal.Add(collectionDefinitionType);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CollectionDefinitionType collectionDefinitionType)
        {
            _collectionDefinitionTypeDal.Delete(collectionDefinitionType);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<CollectionDefinitionType> GetById(int collectionDefinitionTypeId)
        {
            return new SuccessDataResult<CollectionDefinitionType>(_collectionDefinitionTypeDal.Get(p => p.Id == collectionDefinitionTypeId));
        }

        public IDataResult<List<CollectionDefinitionType>> GetList()
        {
            return new SuccessDataResult<List<CollectionDefinitionType>>(_collectionDefinitionTypeDal.GetList().ToList());
        }

        //[ValidationAspect(typeof(CollectionDefinitionTypeValidator))]
        public IResult Update(CollectionDefinitionType collectionDefinitionType)
        {
            IResult result = BusinessRules.Run(CheckIfcollectionDefinitionTypeExists(collectionDefinitionType.Id));
            if (result != null)
                return result;

            _collectionDefinitionTypeDal.Update(collectionDefinitionType);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfcollectionDefinitionTypeExists(int Id)
        {
            var result = _collectionDefinitionTypeDal.GetList(x => x.Id != Id).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
