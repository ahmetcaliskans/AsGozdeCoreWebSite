using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class PaymentTypeManager : IPaymentTypeService
    {
        private IPaymentTypeDal _paymentTypeDal;

        public PaymentTypeManager(IPaymentTypeDal paymentTypeDal)
        {
            _paymentTypeDal = paymentTypeDal;
        }

        [RoleOperation("PaymentType.Insert")]
        public IResult Add(PaymentType paymentType)
        {
            IResult result = BusinessRules.Run(CheckIfpaymentTypeNameExists(paymentType.Id, paymentType.Name));
            if (result != null)
                return result;

            _paymentTypeDal.Add(paymentType);
            return new SuccessResult(Messages.Added);
        }

        [RoleOperation("PaymentType.Delete")]
        public IResult Delete(PaymentType paymentType)
        {
            _paymentTypeDal.Delete(paymentType);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<PaymentType> GetById(int paymentTypeId)
        {
            return new SuccessDataResult<PaymentType>(_paymentTypeDal.Get(p => p.Id == paymentTypeId));
        }

        public IDataResult<PaymentType> GetByName(string paymentTypeName)
        {
            return new SuccessDataResult<PaymentType>(_paymentTypeDal.Get(p => p.Name == paymentTypeName));
        }

        public IDataResult<List<PaymentType>> GetList()
        {
            return new SuccessDataResult<List<PaymentType>>(_paymentTypeDal.GetList().ToList());
        }

        [RoleOperation("PaymentType.Update")]
        public IResult Update(PaymentType paymentType)
        {
            IResult result = BusinessRules.Run(CheckIfpaymentTypeNameExists(paymentType.Id, paymentType.Name));
            if (result != null)
                return result;

            _paymentTypeDal.Update(paymentType);
            return new SuccessResult(Messages.Updated);
        }

        private IResult CheckIfpaymentTypeNameExists(int Id, string paymentTypeName)
        {
            var result = _paymentTypeDal.GetList(x => x.Id != Id && x.Name == paymentTypeName).Any();
            if (result)
            {
                return new ErrorResult(Messages.AlreadyExists);
            }

            return new SuccessResult();
        }


    }
}
