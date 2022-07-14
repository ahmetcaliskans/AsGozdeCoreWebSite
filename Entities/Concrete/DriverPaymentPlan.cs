using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class DriverPaymentPlan : IEntity
    {
        public int Id { get; set; }
        public int DriverInformationId { get; set; }
        public virtual DriverInformation DriverInformation { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public int Sequence { get; set; }
        public string AddedUserName { get; set; }
        public DateTime AddedDateTime { get; set; }
        public string UpdatedUserName { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public int CollectionDefinitionType { get; set; }
    }
}
