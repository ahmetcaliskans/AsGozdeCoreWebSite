using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Office:IEntity
    {
        public int OfficeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }        
    }
}
