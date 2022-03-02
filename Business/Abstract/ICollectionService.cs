using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICollectionService
    {
        IDataResult<Collection> GetById(int collectionId);
        IDataResult<Collection> GetByIdWithDetails(int collectionId);
        IDataResult<List<Collection>> GetListWithDetailsByOfficeId(int officeId);
        IDataResult<string> GetLastDocumentNo(int shortYear);
        IResult Add(Collection collection);
        IResult Update(Collection collection);
        IResult Delete(Collection collection);
    }
}
