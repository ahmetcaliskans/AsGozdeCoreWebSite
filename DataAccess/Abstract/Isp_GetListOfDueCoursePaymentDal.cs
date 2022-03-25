using Core.DataAccess;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface Isp_GetListOfDueCoursePaymentDal : IDtoRepository<sp_GetListOfDueCoursePayment>
    {
        List<sp_GetListOfDueCoursePayment> GetList(DateTime dueDate, int officeId);
    }
}
