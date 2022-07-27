using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class Sp_rCashReport1DetailCollectionManager : Isp_rCashReport1DetailCollectionService
    {
        private Isp_rCashReport1DetailCollectionDal _sp_rCashReport1CollectionDetailDal;
        public Sp_rCashReport1DetailCollectionManager(Isp_rCashReport1DetailCollectionDal sp_rCashReport1CollectionDetailDal)
        {
            _sp_rCashReport1CollectionDetailDal = sp_rCashReport1CollectionDetailDal;
        }
        public IDataResult<List<sp_rCashReport1DetailCollection>> GetListByParameters(int officeId, DateTime? startDate, DateTime? endDate, int paymentTypeId, int collecitonDefinitionId, int collectionDefinitionTypeId,
            int sessionId, int branchId)
        {
            return new SuccessDataResult<List<sp_rCashReport1DetailCollection>>(_sp_rCashReport1CollectionDetailDal.GetListByParameters(officeId, startDate, endDate, paymentTypeId, collecitonDefinitionId, collectionDefinitionTypeId,
                sessionId, branchId));
        }
    }
}

