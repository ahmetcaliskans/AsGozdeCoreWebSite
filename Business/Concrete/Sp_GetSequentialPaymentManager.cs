using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class Sp_GetSequentialPaymentManager : Isp_GetSequentialPaymentService
    {
        private Isp_GetSequentialPaymentDal _sp_GetSequentialPaymentDal;
        public Sp_GetSequentialPaymentManager(Isp_GetSequentialPaymentDal sp_GetSequentialPaymentDal)
        {
            _sp_GetSequentialPaymentDal = sp_GetSequentialPaymentDal;
        }
        public IDataResult<List<sp_GetSequentialPayment>> GetByDriverInformationIdAndCollectionDefinitionTypeId(int driverInformationId, int collectionDefinitionTypeId)
        {
            return new SuccessDataResult<List<sp_GetSequentialPayment>>(_sp_GetSequentialPaymentDal.GetByDriverInformationIdAndCollectionDefinitionTypeId(driverInformationId, collectionDefinitionTypeId));
        }
    }
}
