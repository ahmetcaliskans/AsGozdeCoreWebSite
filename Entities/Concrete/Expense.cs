using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Expense : IEntity
    {
        public int Id { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public string DocumentNo { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Description { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }
        public int ExpenseDefinitionId { get; set; }
        public ExpenseDefinition ExpenseDefinition { get; set; }
        public int? FixtureDefinitionId { get; set; }
        public FixtureDefinition? FixtureDefinition { get; set; }
        public int? PersonnelDefinitionId { get; set; }
        public PersonnelDefinition? PersonnelDefinition { get; set; }
        public decimal Amount{ get; set; }
        public string AddedUserName { get; set; }
        public DateTime AddedDateTime { get; set; }
        public string UpdatedUserName { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}
