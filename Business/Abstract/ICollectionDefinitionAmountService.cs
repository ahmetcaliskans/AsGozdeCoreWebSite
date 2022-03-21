using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICollectionDefinitionAmountService
    {
        IDataResult<CollectionDefinitionAmount> GetById(int collectionDefitinitonAmountId);
        IDataResult<List<CollectionDefinitionAmount>> GetList();
        IDataResult<List<CollectionDefinitionAmount>> GetListWithDetails();
        IResult Add(CollectionDefinitionAmount collectionDefitinitonAmount);
        IResult Update(CollectionDefinitionAmount collectionDefitinitonAmountId);
        IResult Delete(CollectionDefinitionAmount collectionDefitinitonAmountId);
    }
}
