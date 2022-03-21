﻿using Business.Abstract;
using Business.Constants;
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
    public class DriverPaymentPlanManager : IDriverPaymentPlanService
    {
        private IDriverPaymentPlanDal _driverPaymentPlanDal;
        public DriverPaymentPlanManager(IDriverPaymentPlanDal driverPaymentPlanDal)
        {
            _driverPaymentPlanDal = driverPaymentPlanDal;
        }

        public IResult Add(DriverPaymentPlan driverPaymentPlan)
        {
            IResult result = BusinessRules.Run(CheckIfdriverPaymentPlanNameExists(driverPaymentPlan.Id, driverPaymentPlan.DriverInformationId, driverPaymentPlan.PaymentDate));
            if (result != null)
                return result;

            _driverPaymentPlanDal.Add(driverPaymentPlan);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(DriverPaymentPlan driverPaymentPlan)
        {
            _driverPaymentPlanDal.Delete(driverPaymentPlan);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<DriverPaymentPlan> GetById(int driverPaymentPlanId)
        {
            return new SuccessDataResult<DriverPaymentPlan>(_driverPaymentPlanDal.Get(p => p.Id == driverPaymentPlanId));
        }

        public IDataResult<List<DriverPaymentPlan>> GetList()
        {
            return new SuccessDataResult<List<DriverPaymentPlan>>(_driverPaymentPlanDal.GetList().ToList());
        }

        public IDataResult<List<DriverPaymentPlan>> GetListByDriverInformationId(int driverInformationId)
        {
            return new SuccessDataResult<List<DriverPaymentPlan>>(_driverPaymentPlanDal.GetList(x=>x.DriverInformationId == driverInformationId).ToList());
        }

        public IResult Update(DriverPaymentPlan driverPaymentPlan)
        {
            IResult result = BusinessRules.Run(CheckIfdriverPaymentPlanNameExists(driverPaymentPlan.Id, driverPaymentPlan.DriverInformationId, driverPaymentPlan.PaymentDate));
            if (result != null)
                return result;

            _driverPaymentPlanDal.Update(driverPaymentPlan);
            return new SuccessResult(Messages.Updated);
        }        

        private IResult CheckIfdriverPaymentPlanNameExists(int Id, int driverInformationId, DateTime driverPaymentPlanPaymentDate)
        {
            var result = _driverPaymentPlanDal.GetList(x => x.Id != Id && x.DriverInformationId == driverInformationId  && x.PaymentDate.Date == driverPaymentPlanPaymentDate).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }

    }
}
