using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework.Context;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfDriverInformationDal : EfEntityRepositoryBase<DriverInformation, AsGozdeWebSiteDB>, IDriverInformationDal
    {
        public DriverInformation GetByIdWithDetails(int driverInformationId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.DriverInformations.Include(x => x.Office).Include(x => x.Branch).Include(x => x.Session).Where(x => x.Id == driverInformationId);
                return result.FirstOrDefault();
            }
        }

        public List<DriverInformation> GetListWithDetails(int officeId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {                
                var result = context.DriverInformations.Include(x => x.Office).Include(x => x.Branch).Include(x => x.Session).Where(x => x.Office.Id == officeId);
                return result.ToList();
            }
        }
    }
}
