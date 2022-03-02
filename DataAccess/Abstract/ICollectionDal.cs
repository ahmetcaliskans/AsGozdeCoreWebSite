using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICollectionDal : IEntityRepository<Collection>
    {
        List<Collection> GetListWithDetailsByOfficeId(int officeId);
        Collection GetByIdWithDetails(int collectionId);
        string GetLastDocumentNo(int shortYear);
    }
}
