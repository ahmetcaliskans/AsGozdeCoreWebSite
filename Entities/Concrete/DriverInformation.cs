using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class DriverInformation : IEntity
    {
        public int Id { get; set; }
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNo { get; set; }
        public byte[] Image { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        public decimal CourseFee { get; set; }
        public string Email { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }

    }
}
