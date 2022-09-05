using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
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
    public class CollectionDefinitionAmountManager : ICollectionDefinitionAmountService
    {
        private ICollectionDefinitionAmountDal _collectionDefinitionAmountDal;
        public CollectionDefinitionAmountManager(ICollectionDefinitionAmountDal collectionDefinitionAmountDal)
        {
            _collectionDefinitionAmountDal = collectionDefinitionAmountDal;
        }

        [RoleOperation("CollectionDefinitionAmount.Insert")]
        public IResult Add(CollectionDefinitionAmount collectionDefinitionAmount)
        {
            IResult result = BusinessRules.Run(CheckIfCollectionDefinitionAmountExists(collectionDefinitionAmount.Id, collectionDefinitionAmount.CollectionDefinitionId, collectionDefinitionAmount.Year));
            if (result != null)
                return result;

            _collectionDefinitionAmountDal.Add(collectionDefinitionAmount);
            return new SuccessResult(Messages.Added);
        }

        [RoleOperation("CollectionDefinitionAmount.Delete")]
        public IResult Delete(CollectionDefinitionAmount collectionDefinitionAmount)
        {
            _collectionDefinitionAmountDal.Delete(collectionDefinitionAmount);
            return new SuccessResult(Messages.Deleted);
        }

        
        public IDataResult<CollectionDefinitionAmount> GetById(int collectionDefinitionAmountId)
        {
            return new SuccessDataResult<CollectionDefinitionAmount>(_collectionDefinitionAmountDal.Get(p => p.Id == collectionDefinitionAmountId));
        }

        
        public IDataResult<List<CollectionDefinitionAmount>> GetList()
        {
            return new SuccessDataResult<List<CollectionDefinitionAmount>>(_collectionDefinitionAmountDal.GetList().ToList());
        }

        
        public IDataResult<List<CollectionDefinitionAmount>> GetListWithDetails()
        {
            return new SuccessDataResult<List<CollectionDefinitionAmount>>(_collectionDefinitionAmountDal.GetListWithDetails().ToList());
        }

        [RoleOperation("CollectionDefinitionAmount.Update")]
        public IResult Update(CollectionDefinitionAmount collectionDefinitionAmount)
        {
            IResult result = BusinessRules.Run(CheckIfCollectionDefinitionAmountExists(collectionDefinitionAmount.Id, collectionDefinitionAmount.CollectionDefinitionId, collectionDefinitionAmount.Year));
            if (result != null)
                return result;

            _collectionDefinitionAmountDal.Update(collectionDefinitionAmount);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfCollectionDefinitionAmountExists(int Id, int collectionDefinitionId, int year)
        {
            var result = _collectionDefinitionAmountDal.GetList(x => x.Id != Id && x.CollectionDefinitionId == collectionDefinitionId && x.Year == year).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
