using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IDriverInformationService
    {
        IDataResult<DriverInformation> GetById(int driverInformationId);
        IDataResult<DriverInformation> GetByIdWithDetails(int driverInformationId);
        IDataResult<List<DriverInformation>> GetListByOfficeId(int officeId);
        IDataResult<List<DriverInformation>> GetListWithDetails(int officeId);
        IResult Add(DriverInformation driverInformation);
        IResult Update(DriverInformation driverInformation);
        IResult Delete(DriverInformation driverInformation);
    }
}
