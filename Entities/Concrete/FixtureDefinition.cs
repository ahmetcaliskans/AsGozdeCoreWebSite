using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class FixtureDefinition : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public int Year { get; set; }
        public string Note { get; set; }
        public virtual List<Expense> Expenses { get; set; }
    }
}
