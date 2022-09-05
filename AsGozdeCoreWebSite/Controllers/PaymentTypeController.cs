using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Controllers
{
    public class PaymentTypeController : Controller
    {
        IPaymentTypeService _paymentTypeService;

        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            RoleOperation roleOperation = new RoleOperation("PaymentType.Show");
            roleOperation.fn_checkRole();
            var result = _paymentTypeService.GetList();
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult GetPaymentTypeById(int id)
        {
            var result = _paymentTypeService.GetById(id);
            if (result.Success)
            {
                return PartialView("AddEditPaymentType", result.Data);
            }

            return PartialView("AddEditPaymentType", null);

        }

        [HttpPost]
        public IActionResult AddPaymentType(PaymentType paymentType)
        {
            IResult result;
            if (paymentType.Id == null || paymentType.Id <= 0)
                result = _paymentTypeService.Add(paymentType);
            else
                result = _paymentTypeService.Update(paymentType);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeletePaymentTypeById(int id)
        {
            var _paymentTypeResult = _paymentTypeService.GetById(id);

            var result = _paymentTypeService.Delete(_paymentTypeResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }
    }
}
