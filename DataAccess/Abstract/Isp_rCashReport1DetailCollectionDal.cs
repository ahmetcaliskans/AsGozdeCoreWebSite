using Core.DataAccess;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface Isp_rCashReport1DetailCollectionDal : IDtoRepository<sp_rCashReport1DetailCollection>
    {
        List<sp_rCashReport1DetailCollection> GetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int collecitonDefinitionId, int collectionDefinitionTypeId,
            int sessionId, int branchId);
    }
}

