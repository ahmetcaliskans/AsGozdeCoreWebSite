using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class Sp_GetListOfCollectionByOfficeIdManager : Isp_GetListOfCollectionByOfficeIdService
    {
        private Isp_GetListOfCollectionByOfficeIdDal _sp_GetListOfCollectionByOfficeIdDal;
        public Sp_GetListOfCollectionByOfficeIdManager(Isp_GetListOfCollectionByOfficeIdDal sp_GetListOfCollectionByOfficeIdDal)
        {
            _sp_GetListOfCollectionByOfficeIdDal = sp_GetListOfCollectionByOfficeIdDal;
        }
        public IDataResult<List<sp_GetListOfCollectionByOfficeId>> GetList(int officeId)
        {
            return new SuccessDataResult<List<sp_GetListOfCollectionByOfficeId>>(_sp_GetListOfCollectionByOfficeIdDal.GetList(officeId));
        }
    }
}

