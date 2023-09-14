using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ReportLayout : IEntity
    {
        public int ReportId { get; set; }
        public string DisplayName { get; set; }        
        public byte[] LayoutData { get; set; }
    }
}
