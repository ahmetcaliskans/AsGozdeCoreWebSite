using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class RoleType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<Role> Roles { get; set; }
    }
}
