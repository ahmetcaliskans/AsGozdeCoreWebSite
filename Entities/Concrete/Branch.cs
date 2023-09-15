using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Branch : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<DriverInformation> DriverInformations { get; set; }
        public virtual List<PersonnelDefinition> PersonnelDefinitions { get; set; }
    }
}
