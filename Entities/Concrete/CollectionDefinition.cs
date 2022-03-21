using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CollectionDefinition : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
        public bool IsSequence { get; set; }
        public bool IsPrivateLesson { get; set; }
        public bool Active { get; set; }
        public bool PayBySelf { get; set; }
        public virtual List<CollectionDetail> CollectionDetails { get; set; }
        public virtual List<CollectionDefinitionAmount> CollectionDefinitionAmounts { get; set; }
    }
}
