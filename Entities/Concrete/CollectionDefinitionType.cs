using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CollectionDefinitionType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSequence { get; set; }
        public bool IsPayBySelf { get; set; }
        public virtual List<CollectionDefinition> CollectionDefinitions { get; set; }
    }
}
