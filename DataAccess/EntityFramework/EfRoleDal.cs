using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EfRoleDal : EfEntityRepositoryBase<Role, AsGozdeWebSiteDB>, IRoleDal
    {
    }
}
