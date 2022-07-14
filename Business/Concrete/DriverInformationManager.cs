using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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
        
        [ValidationAspect(typeof(DriverInformationValidator))]
        public IResult Add(DriverInformation driverInformation)
        {
            IResult result = BusinessRules.Run(CheckIfDriverExists(driverInformation.Id, driverInformation.IdentityNo, driverInformation.SessionId, driverInformation.OfficeId));
            if (result != null)
                return result;

            _driverInformationDal.Add(driverInformation);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(DriverInformation driverInformation)
        {
            _driverInformationDal.Delete(driverInformation);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(DriverInformationValidator))]
        public IResult Update(DriverInformation driverInformation)
        {
            IResult result = BusinessRules.Run(CheckIfDriverExists(driverInformation.Id, driverInformation.IdentityNo, driverInformation.SessionId, driverInformation.OfficeId));
            if (result != null)
                return result;

            _driverInformationDal.Update(driverInformation);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<DriverInformation>> GetListWithDetails(int officeId)
        {
            return new SuccessDataResult<List<DriverInformation>>(_driverInformationDal.GetListWithDetails(officeId));            
        }

        public IDataResult<DriverInformation> GetByIdWithDetails(int driverInformationId)
        {
            return new SuccessDataResult<DriverInformation>(_driverInformationDal.GetByIdWithDetails(driverInformationId));
        }

        private IResult CheckIfDriverExists(int Id, string IdentityNo, int SessionId, int OfficeId)
        {
            var result = _driverInformationDal.GetList(x => x.Id != Id && x.IdentityNo == IdentityNo && x.SessionId == SessionId && x.OfficeId == OfficeId).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
