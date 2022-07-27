using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface Isp_rCashReport1Service
    {
        IDataResult<List<sp_rCashReport1>> GetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int collecitonDefinitionId, int collectionDefinitionTypeId,
            int sessionId, int branchId);
    }
}
