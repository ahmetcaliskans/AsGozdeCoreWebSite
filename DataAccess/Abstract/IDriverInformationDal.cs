using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IDriverInformationDal : IEntityRepository<DriverInformation>
    {
        List<DriverInformation> GetListWithDetails(int officeId);
        DriverInformation GetByIdWithDetails(int driverInformationId);
    }
}
