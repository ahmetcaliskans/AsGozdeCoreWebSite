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
    public class Efsp_GetListOfCollectionByOfficeIdDal : EfDtoRepositoryBase<sp_GetListOfCollectionByOfficeId, AsGozdeWebSiteDB>, Isp_GetListOfCollectionByOfficeIdDal
    {
        public List<sp_GetListOfCollectionByOfficeId> GetList(int officeId)
        {
            using (AsGozdeWebSiteDB context = new AsGozdeWebSiteDB())
            {
                var result = context.Sp_GetListOfCollectionByOfficeIds.FromSqlRaw("sp_GetListOfCollectionByOfficeId @p0", officeId);
                return result.ToList();
            }
        }
    }
}


