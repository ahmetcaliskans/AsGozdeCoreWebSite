using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserForRegisterDto : IDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Title { get; set; }
    }
}
