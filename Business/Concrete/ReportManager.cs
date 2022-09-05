using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ReportManager : IReportService
    {
        private IReportDal _reportDal;
        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }
        [RoleOperation("Report/CashReport.Show")]
        public IDataResult<List<sp_rCashReport1>> sp_rCashReport1GetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int collecitonDefinitionId, int collectionDefinitionTypeId,
            int sessionId, int branchId, int expenseDefinitionId, int fixtureDefinitionId, int personnelDefinitionId)
        {
            return new SuccessDataResult<List<sp_rCashReport1>>(_reportDal.sp_rCashReport1GetListByParameters(officeId, startDate, endDate, paymentTypeId, collecitonDefinitionId, collectionDefinitionTypeId,
                sessionId, branchId, expenseDefinitionId, fixtureDefinitionId, personnelDefinitionId));
        }

        [RoleOperation("Report/CashReport.Show")]
        public IDataResult<List<sp_rCashReport1DetailCollection>> sp_rCashReport1DetailCollectionGetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int collecitonDefinitionId, int collectionDefinitionTypeId,
            int sessionId, int branchId)
        {
            return new SuccessDataResult<List<sp_rCashReport1DetailCollection>>(_reportDal.sp_rCashReport1DetailCollectionGetListByParameters(officeId, startDate, endDate, paymentTypeId, collecitonDefinitionId, collectionDefinitionTypeId,
                sessionId, branchId));
        }

        [RoleOperation("Report/CashReport.Show")]
        public IDataResult<List<sp_rCashReport1DetailExpense>> sp_rCashReport1DetailExpenseGetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int expenseDefinitionId, int fixtureDefinitionId, 
            int personnelDefinitionId)
        {
            return new SuccessDataResult<List<sp_rCashReport1DetailExpense>>(_reportDal.sp_rCashReport1DetailExpenseGetListByParameters(officeId, startDate, endDate, paymentTypeId, expenseDefinitionId, fixtureDefinitionId,
                personnelDefinitionId));
        }
    }
}
