using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class sp_GetListOfCollectionByOfficeId : IDto
    {
        public int Id { get; set; }
        public string DocumentNo { get; set; }
        public string CollectionDate { get; set; }
        public int DriverInformationId { get; set; }
        public string NameSurname { get; set; }
        public string IdentityNo { get; set; }
        public string Phone1 { get; set; }        
        public string OfficeName { get; set; }
        public string SessionName { get; set; }
        public int SessionYear { get; set; }
        public int SessionSequence { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
