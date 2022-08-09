using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class ExpenseDefinition : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool IsFixtureCanBeSelected { get; set; }
        public bool IsFixtureSelectionRequired { get; set; }
        public bool IsPersonnelCanBeSelected { get; set; }
        public bool IsPersonnelSelectionRequired { get; set; }
        public virtual List<Expense> Expenses { get; set; }
    }
}
