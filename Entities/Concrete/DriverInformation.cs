using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class DriverInformation : IEntity
    {
        public int Id { get; set; }
        public Office Office { get; set; }
        public Session Session { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNo { get; set; }
        public byte[] Image { get; set; }
        public Branch Branch { get; set; }
        public decimal CourseFee { get; set; }

    }
}
