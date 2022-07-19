using Core.DataAccess;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{

    public interface Isp_GetListOfCollectionByOfficeIdDal : IDtoRepository<sp_GetListOfCollectionByOfficeId>
    {
        List<sp_GetListOfCollectionByOfficeId> GetList(int officeId);
    }
}
