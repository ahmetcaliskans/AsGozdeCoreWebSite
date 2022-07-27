using Core.DataAccess;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface Isp_rCashReport1Dal : IDtoRepository<sp_rCashReport1>
    {
        List<sp_rCashReport1> GetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int collecitonDefinitionId, int collectionDefinitionTypeId,
            int sessionId, int branchId);
    }
}
