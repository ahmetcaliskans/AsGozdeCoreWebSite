using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class DriverInformationManager : IDriverInformationService
    {
        private IDriverInformationDal _driverInformationDal;

        public DriverInformationManager(IDriverInformationDal driverInformationDal)
        {
            _driverInformationDal = driverInformationDal;
        }

        public IDataResult<DriverInformation> GetById(int driverInformationId)
        {
            return new SuccessDataResult<DriverInformation>(_driverInformationDal.Get(p => p.Id == driverInformationId));
        }

        public IDataResult<List<DriverInformation>> GetListByOfficeId(int officeId)
        {
            return new SuccessDataResult<List<DriverInformation>>(_driverInformationDal.GetList(x=> x.Office.Id == officeId).ToList());
        }
        public IResult Add(DriverInformation driverInformation)
        {
            _driverInformationDal.Add(driverInformation);
            return new SuccessResult("Başarı ile Eklendi !");
        }

        public IResult Delete(DriverInformation driverInformation)
        {
            _driverInformationDal.Add(driverInformation);
            return new SuccessResult("Başarı ile Silindi !");
        }

        public IResult Update(DriverInformation driverInformation)
        {
            _driverInformationDal.Add(driverInformation);
            return new SuccessResult("Başarı ile Güncellendi !");
        }

        public IDataResult<List<DriverInformation>> GetListWithDetails(int officeId)
        {
            return new SuccessDataResult<List<DriverInformation>>(_driverInformationDal.GetListWithDetails(officeId));            
        }

        public IDataResult<DriverInformation> GetByIdWithDetails(int driverInformationId)
        {
            return new SuccessDataResult<DriverInformation>(_driverInformationDal.GetByIdWithDetails(driverInformationId));
        }
    }
}
