using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface Isp_GetSequentialPaymentService
    {
        IDataResult<List<sp_GetSequentialPayment>> GetByDriverInformationIdAndCollectionDefinitionTypeId(int driverInformationId, int collectionDefinitionTypeId);
    }
}
