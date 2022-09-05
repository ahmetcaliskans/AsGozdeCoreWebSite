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
    public class Sp_GetListOfDriverInformationByOfficeIdManager : Isp_GetListOfDriverInformationByOfficeIdService
    {
        private Isp_GetListOfDriverInformationByOfficeIdDal _sp_GetListOfDriverInformationByOfficeIdDal;
        public Sp_GetListOfDriverInformationByOfficeIdManager(Isp_GetListOfDriverInformationByOfficeIdDal sp_GetListOfDriverInformationByOfficeIdDal)
        {
            _sp_GetListOfDriverInformationByOfficeIdDal = sp_GetListOfDriverInformationByOfficeIdDal;
        }

        [RoleOperation("Driver.Show")]
        public IDataResult<List<sp_GetListOfDriverInformationByOfficeId>> GetList(int officeId, int certificateState)
        {
            return new SuccessDataResult<List<sp_GetListOfDriverInformationByOfficeId>>(_sp_GetListOfDriverInformationByOfficeIdDal.GetList(officeId,certificateState));
        }
    }
}

