using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IReportService
    {
        IDataResult<List<sp_rCashReport1>> sp_rCashReport1GetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int collecitonDefinitionId, int collectionDefinitionTypeId,
            int sessionId, int branchId, int expenseDefinitionId, int fixtureDefinitionId, int personnelDefinitionId);

        IDataResult<List<sp_rCashReport1DetailCollection>> sp_rCashReport1DetailCollectionGetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int collecitonDefinitionId, int collectionDefinitionTypeId,
            int sessionId, int branchId);

        IDataResult<List<sp_rCashReport1DetailExpense>> sp_rCashReport1DetailExpenseGetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int expenseDefinitionId, int fixtureDefinitionId, 
            int personnelDefinitionId);

    }
}
