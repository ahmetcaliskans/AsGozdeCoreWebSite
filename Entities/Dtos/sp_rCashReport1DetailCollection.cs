using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class sp_rCashReport1DetailCollection : IDto
    {
        public int DriverInformationId { get; set; }
        public string NameSurname { get; set; }
        public string IdentityNo { get; set; }
        public string Phone1 { get; set; }
        public string SessionName { get; set; }
        public string BranchName { get; set; }
        public string OfficeName { get; set; }
        public string PaymentName { get; set; }
        public string CollectionDefinitionName { get; set; }
        public int CollectionDefinitionSequence { get; set; }
        public string CollectionDefinitionTypeName { get; set; }
        public decimal Amount { get; set; }
        public decimal Hour { get; set; }
        public string DocumentNo { get; set; }
        public DateTime CollectionDate { get; set; }
        public int CollectionId { get; set; }
        public int CollectionDetailId { get; set; }
    }
}
