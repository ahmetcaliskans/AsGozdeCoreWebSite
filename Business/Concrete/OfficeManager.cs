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
    public class OfficeManager : IOfficeService
    {
        private IOfficeDal _officeDal;

        public OfficeManager(IOfficeDal officeDal)
        {
            _officeDal = officeDal;
        }

        public IDataResult<Office> GetById(int officeId)
        {
            return new SuccessDataResult<Office>(_officeDal.Get(p => p.Id == officeId));
        }

        public IDataResult<List<Office>> GetList()
        {
            return new SuccessDataResult<List<Office>>(_officeDal.GetList().ToList());
        }

        [ValidationAspect(typeof(OfficeValidator))]
        public IResult Add(Office office)
        {
            IResult result = BusinessRules.Run(CheckIfOfficeNameExists(office.Id, office.Name));
            if (result!=null)
                return result;

            _officeDal.Add(office);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Office office)
        {
            _officeDal.Delete(office);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(OfficeValidator))]
        public IResult Update(Office office)
        {
            IResult result = BusinessRules.Run(CheckIfOfficeNameExists(office.Id, office.Name));
            if (result != null)
                return result;

            _officeDal.Update(office);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfOfficeNameExists(int Id, string officeName)
        {
            var result = _officeDal.GetList(x => x.Id != Id && x.Name == officeName).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }
    }
}
