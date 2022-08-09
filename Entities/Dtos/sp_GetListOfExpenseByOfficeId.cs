using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class sp_GetListOfExpenseByOfficeId : IDto
    {
        public int Id { get; set; }
        public string DocumentNo { get; set; }
        public string ExpenseDate { get; set; }
        public string Description { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public decimal Amount { get; set; }
        public int ExpenseDefinitionId { get; set; }
        public string ExpenseDefinitionName { get; set; }
        public string ExpenseDefinitionDescription { get; set; }
        public int? FixtureDefinitionId { get; set; }
        public string FixtureDefinitionName { get; set; }
        public string FixtureDefinitionDescription { get; set; }
        public int? PersonnelDefinitionId { get; set; }
        public string NameSurname { get; set; }
        public string IdentityNo { get; set; }
        public string Phone1 { get; set; }
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
    }
}
