using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class Efsp_GetListOfDriverInformationByOfficeIdDal : EfDtoRepositoryBase<sp_GetListOfDriverInformationByOfficeId, AsGozdeWebSiteDB>, Isp_GetListOfDriverInformationByOfficeIdDal
    {
        public List<sp_GetListOfDriverInformationByOfficeId> GetList(int officeId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Sp_GetListOfDriverInformationByOfficeIds.FromSqlRaw("sp_GetListOfDriverInformationByOfficeId @p0",  officeId);
                return result.ToList();
            }
        }
    }
}

