using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
    public class CollectionDefinitionManager : ICollectionDefinitionService
    {
        private ICollectionDefinitionDal _collectionDefinitionDal;
        public CollectionDefinitionManager(ICollectionDefinitionDal collectionDefinitionDal)
        {
            _collectionDefinitionDal = collectionDefinitionDal;
        }

        [RoleOperation("CollectionDefinition.Insert")]
        [ValidationAspect(typeof(CollectionDefinitionValidator))]
        public IResult Add(CollectionDefinition collectionDefinition)
        {
            IResult result = BusinessRules.Run(CheckIfcollectionDefinitionNameExists(collectionDefinition));
            if (result != null)
                return result;

            _collectionDefinitionDal.Add(collectionDefinition);
            return new SuccessResult(Messages.Added);
        }

        [RoleOperation("CollectionDefinition.Delete")]
        public IResult Delete(CollectionDefinition collectionDefinition)
        {
            _collectionDefinitionDal.Delete(collectionDefinition);
            return new SuccessResult(Messages.Deleted);
        }

        
        public IDataResult<CollectionDefinition> GetById(int collectionDefinitionId)
        {
            return new SuccessDataResult<CollectionDefinition>(_collectionDefinitionDal.Get(p => p.Id == collectionDefinitionId));
        }

        
        public IDataResult<CollectionDefinition> GetByIdWithDetails(int collectionDefinitionId)
        {
            return new SuccessDataResult<CollectionDefinition>(_collectionDefinitionDal.GetByIdWithDetails(collectionDefinitionId));
        }

        
        public IDataResult<CollectionDefinition> GetByName(string collectionDefinitionName)
        {
            return new SuccessDataResult<CollectionDefinition>(_collectionDefinitionDal.Get(p => p.Name == collectionDefinitionName));
        }

        
        public IDataResult<List<CollectionDefinition>> GetList()
        {
            return new SuccessDataResult<List<CollectionDefinition>>(_collectionDefinitionDal.GetList().ToList());
        }

        
        public IDataResult<List<CollectionDefinition>> GetListWithDetails()
        {
            return new SuccessDataResult<List<CollectionDefinition>>(_collectionDefinitionDal.GetListWithDetails());
        }

        [RoleOperation("CollectionDefinition.Update")]
        [ValidationAspect(typeof(CollectionDefinitionValidator))]
        public IResult Update(CollectionDefinition collectionDefinition)
        {
            IResult result = BusinessRules.Run(CheckIfcollectionDefinitionNameExists(collectionDefinition));
            if (result != null)
                return result;

            _collectionDefinitionDal.Update(collectionDefinition);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfcollectionDefinitionNameExists(CollectionDefinition collectionDefinition)
        {
            var result = _collectionDefinitionDal.GetList(x => x.Id != collectionDefinition.Id && 
            ((x.Name == collectionDefinition.Name && x.Sequence == collectionDefinition.Sequence) || (!x.IsSequence && x.CollectionDefinitionTypeId==collectionDefinition.CollectionDefinitionTypeId) )).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
