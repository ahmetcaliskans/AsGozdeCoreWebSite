using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class sp_rCashReport1 : IDto
    {
        public string PaymentTypeName { get; set; }
        public string OfficeName { get; set; }
        public decimal TotalCollectionAmount { get; set; }
        public decimal TotalExpenseAmount { get; set; }
        public decimal TotalBalance { get; set; }

    }
}
