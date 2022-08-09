using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class sp_rCashReport1DetailExpense : IDto
    {
        public int Id { get; set; }
        public string DocumentNo { get; set; }
        public string ExpenseDate { get; set; }
        public string Description { get; set; }
        public string PaymentTypeName { get; set; }
        public string ExpenseDefinitionName { get; set; }
        public string FixtureDefinitionName { get; set; }
        public string PersonnelNameSurname { get; set; }
        public decimal Amount { get; set; }
        public string OfficeName { get; set; }
    }
}
