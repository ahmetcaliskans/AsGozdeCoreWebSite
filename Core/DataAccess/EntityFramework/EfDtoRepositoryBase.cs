using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfDtoRepositoryBase<TEntity, TContext> : IDtoRepository<TEntity>
        where TEntity : class, IDto, new()
        where TContext : DbContext, new()
    {        


    }
}
