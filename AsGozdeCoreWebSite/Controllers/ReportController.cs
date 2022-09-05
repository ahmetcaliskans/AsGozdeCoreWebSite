using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Controllers
{
    public class ReportController : Controller
    {
        private IReportService _sp_rCashReport1Service;
        private Isp_GetListOfDueCoursePaymentService _sp_GetListOfDueCoursePaymentService;
        public ReportController(IReportService sp_rCashReport1Service,
            Isp_GetListOfDueCoursePaymentService sp_GetListOfDueCoursePaymentService)
        {
            _sp_rCashReport1Service = sp_rCashReport1Service;
            _sp_GetListOfDueCoursePaymentService = sp_GetListOfDueCoursePaymentService;
        }
        public IActionResult Index()
        {
            ViewData["OfficeId"] = Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value);
            return View();
        }

        [HttpGet]
        public IActionResult CashReport()
        {
            RoleOperation roleOperation = new RoleOperation("Report/CashReport.Show");
            roleOperation.fn_checkRole();
            ViewData["OfficeId"] = Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value);
            return View("CashReport");
        }

        public IActionResult GetCashReport1(DateTime? startDate, DateTime? endDate, int paymentTypeId, int collectionDefinitionId, int collectionDefinitionTypeId, int sessionId, int branchId, int expenseDefinitionId,
            int fixtureDefinitionId, int personnelDefinitionId)
        {
            var result = _sp_rCashReport1Service.sp_rCashReport1GetListByParameters(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value), startDate, endDate, 
                paymentTypeId, collectionDefinitionId, collectionDefinitionTypeId, sessionId, branchId, expenseDefinitionId, fixtureDefinitionId , personnelDefinitionId);
            ViewData["OfficeId"] = Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value);
            if (result.Data != null)
            {
                return Json(result.Data);
            }
            return Ok(result.Data);
        }

        public IActionResult GetCashReport1DetailCollection(DateTime? startDate, DateTime? endDate, int paymentTypeId, int collectionDefinitionId, int collectionDefinitionTypeId, int sessionId, int branchId)
        {
            var result = _sp_rCashReport1Service.sp_rCashReport1DetailCollectionGetListByParameters(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value), startDate, endDate,
                paymentTypeId, collectionDefinitionId, collectionDefinitionTypeId, sessionId, branchId);
            if (result.Data != null)
            {
                return Json(result.Data);
            }
            return Ok(result.Data);
        }

        public IActionResult GetCashReport1DetailExpense(DateTime? startDate, DateTime? endDate, int paymentTypeId, int expenseDefinitionId,  int fixtureDefinitionId, int personnelDefinitionId)
        {
            var result = _sp_rCashReport1Service.sp_rCashReport1DetailExpenseGetListByParameters(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value), startDate, endDate,
                paymentTypeId, expenseDefinitionId, fixtureDefinitionId, personnelDefinitionId);
            if (result.Data != null)
            {
                return Json(result.Data);
            }
            return Ok(result.Data);
        }

        [HttpGet]
        public IActionResult ListOfDueCoursePayments()
        {
            RoleOperation roleOperation = new RoleOperation("Report/ListOfDueCoursePayments.Show");
            roleOperation.fn_checkRole();
            return View("ListOfDueCoursePayments");
        }

        public IActionResult GetListOfDueCoursePayments(int dueType)
        {
            var result = _sp_GetListOfDueCoursePaymentService.GetList(dueType, Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value));
            if (result.Data != null)
            {
                return Json(result.Data);
            }
            return Ok(result.Data);
        }

        

        
    }
}
