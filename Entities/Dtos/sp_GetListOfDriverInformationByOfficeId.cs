using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class sp_GetListOfDriverInformationByOfficeId : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string NameSurname { get; set; }
        public string IdentityNo { get; set; }
        public string Phone1 { get; set; }
        public decimal CourseFee { get; set; }
        public decimal CourseFeePlus { get; set; }     
        public decimal Balance { get; set; }
        public string OfficeName { get; set; }
        public string SessionName { get; set; }
        public int SessionYear { get; set; }
        public int SessionSequence { get; set; }
        public string BranchName { get; set; }
        public bool IsCertificateDelivered { get; set; }

    }
}
