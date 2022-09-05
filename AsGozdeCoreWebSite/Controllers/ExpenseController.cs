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
    public class ExpenseController : Controller
    {
        private IExpenseService _expenseService;
        private IExpenseDefinitionService _expenseDefinitionService;
        public ExpenseController(IExpenseService expenseService, IExpenseDefinitionService expenseDefinitionService)
        {
            _expenseService = expenseService;
            _expenseDefinitionService = expenseDefinitionService;
        }
        public IActionResult Index()
        {
            RoleOperation roleOperation = new RoleOperation("Expense.Show");
            roleOperation.fn_checkRole();
            return View();
        }

        public IActionResult GetListOfExpenseByOfficeId()
        {
            var result = _expenseService.GetListWithDetailsByOfficeId(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value));
            if (result != null)
            {
                return Ok(result.Data);
            }

            return Ok(result.Data);
        }

        [HttpGet]
        public IActionResult GetExpenseByIdWithDetails(int id)
        {
            ViewData["OfficeId"] = Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value);

            var expenseDefinitionResult = _expenseDefinitionService.GetList();
            ViewData["IsFixtureCanBeSelected"] = (expenseDefinitionResult.Data != null || expenseDefinitionResult.Data.Count > 0) ? expenseDefinitionResult.Data.OrderBy(x => x.Name).FirstOrDefault().IsFixtureCanBeSelected : false;
            ViewData["IsPersonnelCanBeSelected"] = (expenseDefinitionResult.Data != null || expenseDefinitionResult.Data.Count > 0) ? expenseDefinitionResult.Data.OrderBy(x => x.Name).FirstOrDefault().IsPersonnelCanBeSelected : false;

            var result = _expenseService.GetByIdWithDetails(id);
            if (result.Success)
            {
                if (result.Data != null)
                {
                    ViewData["IsFixtureCanBeSelected"] = result.Data.ExpenseDefinition.IsFixtureCanBeSelected;
                    ViewData["IsPersonnelCanBeSelected"] = result.Data.ExpenseDefinition.IsPersonnelCanBeSelected;
                }
                    
                return PartialView("AddEditExpense", result.Data);
            }

            return PartialView("AddEditExpense", null);

        }

        [HttpPost]
        public IActionResult Addexpense(Expense expense)
        {
            IResult result;

            expense.OfficeId = Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value);
            expense.UpdatedDateTime = DateTime.Now;
            expense.UpdatedUserName = User.Identity.Name;

            var expenseDefinitionResult = _expenseDefinitionService.GetById(expense.ExpenseDefinitionId);
            if (expenseDefinitionResult!=null)
            {
                if (expenseDefinitionResult.Data.IsFixtureCanBeSelected && expenseDefinitionResult.Data.IsFixtureSelectionRequired && (expense.FixtureDefinitionId == null || expense.FixtureDefinitionId==0))
                {
                    return BadRequest("Demirbaş Seçimi Zorunlu !");
                }

                if (expenseDefinitionResult.Data.IsPersonnelCanBeSelected && expenseDefinitionResult.Data.IsPersonnelSelectionRequired && (expense.PersonnelDefinitionId == null || expense.PersonnelDefinitionId == 0))
                {
                    return BadRequest("Personel Seçimi Zorunlu !");
                }

                if (expense.PersonnelDefinitionId == 0)
                    expense.PersonnelDefinitionId = null;

                if (expense.FixtureDefinitionId == 0)
                    expense.FixtureDefinitionId = null;

            }


            if (expense.Id == null || expense.Id <= 0)
            {
                string documentNo = "G"+expense.ExpenseDate.Year.ToString().Substring(2, 2) + "00000";
                var documentNoResult = _expenseService.GetLastDocumentNo("G"+expense.ExpenseDate.Year.ToString().Substring(2, 2));
                if (documentNoResult.Success)
                {
                    documentNo = (documentNoResult.Message != null && !string.IsNullOrEmpty(documentNoResult.Message)) ? documentNoResult.Message : documentNo;
                }
                documentNo = documentNo.Substring(0, 2) + (Convert.ToInt32(documentNo.Substring(2, 6)) + 1).ToString().PadLeft(6, '0');
                expense.DocumentNo = documentNo;
                expense.AddedDateTime = DateTime.Now;
                expense.AddedUserName = User.Identity.Name;               
                result = _expenseService.Add(expense);
            }                
            else
            {
                var expenseResult = _expenseService.GetByIdWithDetails(expense.Id);
                if (expenseResult!=null)
                {
                    expense.DocumentNo = expenseResult.Data.DocumentNo;
                    expense.AddedDateTime = expenseResult.Data.AddedDateTime;
                    expense.AddedUserName = expenseResult.Data.AddedUserName;                    
                }
                result = _expenseService.Update(expense);

            }
                

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeleteExpenseById(int id)
        {
            var _expenseResult = _expenseService.GetById(id);

            var result = _expenseService.Delete(_expenseResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost]
        public IActionResult GetExpenseDefinitionInformations(int id)
        {
            var expenseDefinitionResult = _expenseDefinitionService.GetById(id);
            ViewData["OfficeId"] = Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value);
            ViewData["IsFixtureCanBeSelected"] = false;
            ViewData["IsPersonnelCanBeSelected"] = false;

            if (expenseDefinitionResult.Success && expenseDefinitionResult.Data != null)
            {
                ViewData["IsFixtureCanBeSelected"] = expenseDefinitionResult.Data.IsFixtureCanBeSelected;
                ViewData["IsPersonnelCanBeSelected"] = expenseDefinitionResult.Data.IsPersonnelCanBeSelected;
                return Ok(string.Format("{0}/{1}", expenseDefinitionResult.Data.IsFixtureCanBeSelected, expenseDefinitionResult.Data.IsPersonnelCanBeSelected));
            }
            return Ok();
        }
    }
}
