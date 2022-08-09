using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public bool Active { get; set; }
        public int OfficeId { get; set; }
        public int RoleTypeId { get; set; }
        public RoleType RoleType { get; set; }
    }
}
