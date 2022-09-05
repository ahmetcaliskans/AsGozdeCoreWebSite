using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class RoleFormDefinition : IEntity
    {
        public int Id { get; set; }
        public string FormName { get; set; }
        public string FormSubName { get; set; }
        public string Description { get; set; }
        public string SpecialRole1Description { get; set; }
        public string SpecialRole2Description { get; set; }
        public string SpecialRole3Description { get; set; }
        public string SpecialRole4Description { get; set; }
        public string SpecialRole5Description { get; set; }
        public virtual List<Role> Roles { get; set; }

    }
}
