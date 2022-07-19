using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface Isp_GetListOfCollectionByOfficeIdService
    {
        IDataResult<List<sp_GetListOfCollectionByOfficeId>> GetList(int officeId);
    }
}

