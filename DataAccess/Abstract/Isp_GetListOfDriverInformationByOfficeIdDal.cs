using Core.DataAccess;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{

    public interface Isp_GetListOfDriverInformationByOfficeIdDal : IDtoRepository<sp_GetListOfDriverInformationByOfficeId>
    {
        List<sp_GetListOfDriverInformationByOfficeId> GetList(int officeId);
    }
}
