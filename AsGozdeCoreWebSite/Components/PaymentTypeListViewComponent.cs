using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Components
{
    public class PaymentTypeListViewComponent : ViewComponent
    {
        private IPaymentTypeService _paymentTypeService;

        public PaymentTypeListViewComponent(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int paymentTypeId)
        {
            var result = _paymentTypeService.GetList();
            dynamic mymodel = new System.Dynamic.ExpandoObject();
            mymodel.PaymentType = result.Data.OrderByDescending(x => x.Name).ToList();
            mymodel.SelectedId = paymentTypeId == null ? 0 : paymentTypeId;
            //return await Task.FromResult((IViewComponentResult)View("GetPaymentTypeList", result.Data));
            return View("PaymentTypeList", mymodel);
        }
    }
}
