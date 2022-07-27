using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class Sp_rCashReport1Manager : Isp_rCashReport1Service
    {
        private Isp_rCashReport1Dal _sp_rCashReport1Dal;
        public Sp_rCashReport1Manager(Isp_rCashReport1Dal sp_rCashReport1Dal)
        {
            _sp_rCashReport1Dal = sp_rCashReport1Dal;
        }
        public IDataResult<List<sp_rCashReport1>> GetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int collecitonDefinitionId, int collectionDefinitionTypeId,
            int sessionId, int branchId)
        {
            return new SuccessDataResult<List<sp_rCashReport1>>(_sp_rCashReport1Dal.GetListByParameters(officeId, startDate, endDate, paymentTypeId, collecitonDefinitionId, collectionDefinitionTypeId,
                sessionId, branchId));
        }
    }
}
