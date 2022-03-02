using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Collection : IEntity
    {
        public int Id { get; set; }
        public string DocumentNo { get; set; }
        public DateTime CollectionDate { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public int DriverInformationId { get; set; }
        public DriverInformation DriverInformation { get; set; }
        public decimal TotalAmount { get; set; }
        public int AddedUserId{ get; set; }
        public string AddedUserName { get; set; }
        public DateTime AddedDateTime { get; set; }
        public string UpdatedUserName { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public virtual List<CollectionDetail> CollectionDetails { get; set; }
    }
}
