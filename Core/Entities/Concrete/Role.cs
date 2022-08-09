using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class Role: IEntity
    {
        public int Id { get; set; }
        public int RoleTypeId { get; set; }
        public RoleType RoleType { get; set; }
        public int FormName { get; set; }
        public string FormSubName { get; set; }
        public bool Show { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Print { get; set; }
        public bool Export { get; set; }
        public bool SpecialRole1 { get; set; }
        public string SpecialRole1Description { get; set; }
        public bool SpecialRole2 { get; set; }
        public string SpecialRole2Description { get; set; }
        public bool SpecialRole3 { get; set; }
        public string SpecialRole3Description { get; set; }
        public bool SpecialRole4 { get; set; }
        public string SpecialRole4Description { get; set; }
        public bool SpecialRole5 { get; set; }
        public string SpecialRole5Description { get; set; }
    }
}
