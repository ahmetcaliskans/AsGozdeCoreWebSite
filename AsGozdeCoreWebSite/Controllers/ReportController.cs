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
        private Isp_rCashReport1Service _sp_rCashReport1Service;
        private Isp_rCashReport1DetailCollectionService _sp_rCashReport1DetailCollectionService;
        private Isp_GetListOfDueCoursePaymentService _sp_GetListOfDueCoursePaymentService;
        public ReportController(Isp_rCashReport1Service sp_rCashReport1Service, Isp_rCashReport1DetailCollectionService sp_rCashReport1DetailCollectionService,
            Isp_GetListOfDueCoursePaymentService sp_GetListOfDueCoursePaymentService)
        {
            _sp_rCashReport1Service = sp_rCashReport1Service;
            _sp_rCashReport1DetailCollectionService = sp_rCashReport1DetailCollectionService;
            _sp_GetListOfDueCoursePaymentService = sp_GetListOfDueCoursePaymentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CashReport()
        {
            return View("CashReport");
        }

        public IActionResult GetCashReport1(DateTime? startDate, DateTime? endDate, int paymentTypeId, int collectionDefinitionId, int collectionDefinitionTypeId, int sessionId, int branchId)
        {
            var result = _sp_rCashReport1Service.GetListByParameters(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value), startDate, endDate, 
                paymentTypeId, collectionDefinitionId, collectionDefinitionTypeId, sessionId, branchId);
            if (result.Data != null)
            {
                return Json(result.Data);
            }
            return Ok(result.Data);
        }

        public IActionResult GetCashReport1DetailCollection(DateTime? startDate, DateTime? endDate, int paymentTypeId, int collectionDefinitionId, int collectionDefinitionTypeId, int sessionId, int branchId)
        {
            var result = _sp_rCashReport1DetailCollectionService.GetListByParameters(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value), startDate, endDate,
                paymentTypeId, collectionDefinitionId, collectionDefinitionTypeId, sessionId, branchId);
            if (result.Data != null)
            {
                return Json(result.Data);
            }
            return Ok(result.Data);
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
                return Json(result.Data);
            }
            return Ok(result.Data);
        }

        

        
    }
}
