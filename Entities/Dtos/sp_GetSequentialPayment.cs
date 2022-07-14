using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class sp_GetSequentialPayment : IDto
    {
        public int CollectionDefinitionId { get; set; }
        public string CollectionDefinitionName { get; set; }
        public string CollectionDefinitionDescription { get; set; }
        public int CollectionDefinitionSequence { get; set; }
        public bool CollectionDefinitionPayBySelf { get; set; }
        public int CollectionDefinitionTypeId { get; set; }        
        public string CollectionDefinitionTypeName { get; set; }
        public int? CollectionDetailId { get; set; }
        public bool CollectionDetailPaidBySelf { get; set; }
        public int? PaymentTypeId { get; set; }
        public string PaymentTypeName { get; set; }
        public int? CollectionId { get; set; }
        public decimal? CollectionDetailAmount { get; set; }
        public string DocumentNo { get; set; }
        public DateTime? CollectionDate { get; set; }
        public int? DriverInformationId { get; set; }
        public decimal Hour { get; set; }
    }
}
