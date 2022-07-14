using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class sp_GetPayment : IDto
    {
        public int DriverPaymentPlanId { get; set; }
        public int DriverPaymentPlanSequence { get; set; }
        public int DriverPaymentPlanDriverInformationId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentPlanAmount { get; set; }
        public decimal Debit { get; set; }
        public int ClosingCollectionCount { get; set; }
        public string CollectionIds { get; set; }
        public string CollectionDetailIds { get; set; }
        public string CollectionTypeNames { get; set; }
        public string CollectionDates { get; set; }
        public int CollectionDefinitionId { get; set; }
        public int CollectionDefinitionTypeId { get; set; }
    }
}
