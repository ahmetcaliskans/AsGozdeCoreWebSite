using Core.Utilities.Results;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface Isp_GetListOfDueCoursePaymentService
    {
        IDataResult<List<sp_GetListOfDueCoursePayment>> GetList(DateTime dueDate, int officeId);
    }
}
