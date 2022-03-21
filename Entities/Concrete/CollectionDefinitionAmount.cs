using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CollectionDefinitionAmount : IEntity
    {
        public int Id { get; set; }
        public int CollectionDefinitionId { get; set; }
        public virtual CollectionDefinition CollectionDefinition { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
        public string AddedUserName { get; set; }
        public DateTime AddedDateTime { get; set; }
        public string UpdatedUserName { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
