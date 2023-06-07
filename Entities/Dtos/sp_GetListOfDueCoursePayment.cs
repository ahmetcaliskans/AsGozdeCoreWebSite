using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class sp_GetListOfDueCoursePayment : IDto
    {
        public string OfficeName { get; set; }
        public string SessionName { get; set; }
        public int SessionYear { get; set; }
        public int SessionSequence { get; set; }
        public string BranchName { get; set; }
        public int DriverInformationId { get; set; }
        public string NameSurname { get; set; }
        public string IdentityNo { get; set; }
        public string Phone1 { get; set; }
        public decimal CourseFee { get; set; }
        public decimal CourseFeePlus { get; set; }        
        public int DriverPaymentPlanId { get; set; }
        public string CollectionDefinitionTypeName { get; set; }
        public int DriverPaymentPlanSequence { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentDateYear { get; set; }
        public string PaymentDateMonthName { get; set; }
        public decimal Amount { get; set; }
        public decimal DebitinMonth { get; set; }
    }
}
