using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Office : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string WebAddress { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string TradeRegisterNumber { get; set; }
        public string TaxOfficeName { get; set; }
        public string TaxOfficeNo { get; set; }
        public virtual List<DriverInformation> DriverInformations { get; set; }
        public virtual List<Collection> Collections { get; set; }
        public virtual List<Expense> Expenses { get; set; }
        public virtual List<PersonnelDefinition> PersonnelDefinitions { get; set; }
    }
}
