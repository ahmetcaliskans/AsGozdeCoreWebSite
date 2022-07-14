using Core.DataAccess;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface Isp_GetSequentialPaymentDal : IDtoRepository<sp_GetSequentialPayment>
    {
        List<sp_GetSequentialPayment> GetByDriverInformationIdAndCollectionDefinitionTypeId(int driverInformationId, int collectionDefinitionTypeId);
    }
}
