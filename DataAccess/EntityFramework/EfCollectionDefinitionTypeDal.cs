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
    public class EfCollectionDefinitionTypeDal : EfEntityRepositoryBase<CollectionDefinitionType, AsGozdeWebSiteDB>, ICollectionDefinitionTypeDal
    {
        
    }
}
