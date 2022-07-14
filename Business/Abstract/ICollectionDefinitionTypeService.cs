using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICollectionDefinitionTypeService
    {
        IDataResult<CollectionDefinitionType> GetById(int collectionDefinitionTypeId);
        IDataResult<List<CollectionDefinitionType>> GetList();
        IResult Add(CollectionDefinitionType collectionDefinitionType);
        IResult Update(CollectionDefinitionType collectionDefinitionType);
        IResult Delete(CollectionDefinitionType collectionDefinitionType);
    }
}