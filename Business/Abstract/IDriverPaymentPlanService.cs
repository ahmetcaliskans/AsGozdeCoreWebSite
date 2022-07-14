using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDriverPaymentPlanService
    {
        IDataResult<DriverPaymentPlan> GetById(int driverPaymentPlanId);
        IDataResult<List<DriverPaymentPlan>> GetList();
        IDataResult<List<DriverPaymentPlan>> GetListByDriverInformationId(int driverInformationId, int collectionDefinitionType);
        IResult Add(DriverPaymentPlan driverPaymentPlan);
        IResult Update(DriverPaymentPlan driverPaymentPlan);
        IResult Delete(DriverPaymentPlan driverPaymentPlan);
    }
}
