using Core.DataAccess;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface Isp_GetPaymentDal : IDtoRepository<sp_GetPayment>
    {
        List<sp_GetPayment> GetByDriverInformationId(int driverInformationId,  int  collectionDefinitionTypeId);
    }
}
