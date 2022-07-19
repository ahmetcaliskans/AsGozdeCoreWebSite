using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Controllers
{
    public class ReportController : Controller
    {
        private Isp_GetListOfDueCoursePaymentService _sp_GetListOfDueCoursePaymentService;
        public ReportController(Isp_GetListOfDueCoursePaymentService sp_GetListOfDueCoursePaymentService)
        {
            _sp_GetListOfDueCoursePaymentService = sp_GetListOfDueCoursePaymentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ListOfDueCoursePayments()
        {            
            return View("ListOfDueCoursePayments");
        }

        public IActionResult GetListOfDueCoursePayments()
        {
            var result = _sp_GetListOfDueCoursePaymentService.GetList(DateTime.Now.Date, Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value));
            if (result.Data != null)
            {
                return Ok(result.Data);
            }
            return Ok(result.Data);
        }
    }
}
