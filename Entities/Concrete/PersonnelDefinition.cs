using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PersonnelDefinition : IEntity
    {
        public int Id { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNo { get; set; }
        public string Image { get; set; }
        public string Job { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }        
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Note { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Active { get; set; }
        public virtual List<Expense> Expenses { get; set; }
    }
}
