using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentTypeService
    {
        IDataResult<PaymentType> GetById(int paymentTypeId);
        IDataResult<PaymentType> GetByName(string paymentTypeName);
        IDataResult<List<PaymentType>> GetList();
        IResult Add(PaymentType paymentType);
        IResult Update(PaymentType paymentType);
        IResult Delete(PaymentType paymentType);
    }

}
