using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface Isp_GetPaymentService
    {
        IDataResult<List<sp_GetPayment>> GetByDriverInformationId(int driverInformationId, int collectionDefinitionTypeId);
    }
}
