using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Concrete
{
    public class PaymentType :IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public virtual List<CollectionDetail> CollectionDetails { get; set; }
        public virtual List<Expense> Expenses { get; set; }
    }
}
