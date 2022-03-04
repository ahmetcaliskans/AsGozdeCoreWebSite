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
    public class EfCollectionDal : EfEntityRepositoryBase<Collection, AsGozdeWebSiteDB>, ICollectionDal
    {
        public Collection GetByIdWithDetails(int collectionId)
        {            
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Collections.Include(x => x.Office).Include(x => x.DriverInformation).Where(x => x.Id == collectionId);
                if (result.Count()>0)
                {                    
                    var result2 = from d in result
                                  select new { Balance = context.fn_GetDriverBalance(d.DriverInformationId) };
                    result.FirstOrDefault().DriverInformation.Balance = result2.FirstOrDefault().Balance;
                }                
                return result.FirstOrDefault();
            }
        }        

        public List<Collection> GetListWithDetailsByOfficeId(int officeId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Collections.Include(x => x.Office).Include(x => x.DriverInformation).Include(x=>x.DriverInformation.Session).Where(x => x.Office.Id == officeId);
                return result.ToList();
            }
        }

        public string GetLastDocumentNo(int shortYear)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Collections.Where(x=>x.DocumentNo.StartsWith(shortYear.ToString())).Max(x => x.DocumentNo);
                return result;
            }
        }
    }
}
