using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccess
{
    public interface IDtoRepository<T> where T : class, IDto, new()
    {

    }
}
