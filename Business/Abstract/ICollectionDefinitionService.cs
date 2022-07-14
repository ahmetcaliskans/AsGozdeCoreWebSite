using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICollectionDefinitionService
    {
        IDataResult<CollectionDefinition> GetById(int collectionDefinitionId);
        IDataResult<CollectionDefinition> GetByIdWithDetails(int collectionDefinitionId);
        IDataResult<CollectionDefinition> GetByName(string collectionDefinitionName);
        IDataResult<List<CollectionDefinition>> GetList();
        IDataResult<List<CollectionDefinition>> GetListWithDetails();
        IResult Add(CollectionDefinition collectionDefinition);
        IResult Update(CollectionDefinition collectionDefinition);
        IResult Delete(CollectionDefinition collectionDefinition);
    }
}
