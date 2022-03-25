using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class sp_GetListOfDueCoursePayment : IDto
    {
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public string SessionDescription { get; set; }
        public int SessionYear { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int DriverInformationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal CourseFee { get; set; }
        public int DriverPaymentPlanId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalCourseCollectionAmount { get; set; }
        public decimal TotalDebitByPaymentDate { get; set; }
        public decimal DebitinMonth { get; set; }
        public decimal LastDebit { get; set; }
    }
}
