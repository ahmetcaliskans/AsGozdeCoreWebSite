using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class Sp_GetListOfDueCoursePaymentManager : Isp_GetListOfDueCoursePaymentService
    {
        private Isp_GetListOfDueCoursePaymentDal _sp_GetListOfDueCoursePaymentDal;
        public Sp_GetListOfDueCoursePaymentManager(Isp_GetListOfDueCoursePaymentDal sp_GetListOfDueCoursePaymentDal)
        {
            _sp_GetListOfDueCoursePaymentDal = sp_GetListOfDueCoursePaymentDal;
        }
        public IDataResult<List<sp_GetListOfDueCoursePayment>> GetList(int dueType, int officeId)
        {
            return new SuccessDataResult<List<sp_GetListOfDueCoursePayment>>(_sp_GetListOfDueCoursePaymentDal.GetList(dueType, officeId));
        }
    }
}
