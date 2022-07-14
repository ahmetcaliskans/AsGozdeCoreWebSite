using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class Sp_GetPaymentManager : Isp_GetPaymentService
    {
        private Isp_GetPaymentDal _sp_GetPaymentDal;
        public Sp_GetPaymentManager(Isp_GetPaymentDal sp_GetPaymentDal)
        {
            _sp_GetPaymentDal = sp_GetPaymentDal;
        }
        public IDataResult<List<sp_GetPayment>> GetByDriverInformationId(int driverInformationId, int collectionDefinitionTypeId)
        {
            return new SuccessDataResult<List<sp_GetPayment>>(_sp_GetPaymentDal.GetByDriverInformationId(driverInformationId, collectionDefinitionTypeId));
        }
    }
}
