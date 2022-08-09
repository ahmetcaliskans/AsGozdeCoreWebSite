using System;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AsGozdeCoreWebSite.Controllers
{
    public class ExpenseDefinitionController : Controller
    {
        private IExpenseDefinitionService _expenseDefinitionService;
        public ExpenseDefinitionController(IExpenseDefinitionService expenseDefinitionService)
        {
            _expenseDefinitionService = expenseDefinitionService;
        }
        public IActionResult Index()
        {
            var result = _expenseDefinitionService.GetList();
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult GetExpenseDefinitionById(int id)
        {
            var result = _expenseDefinitionService.GetById(id);
            if (result.Success)
            {
                return PartialView("AddEditExpenseDefinition", result.Data);
            }

            return PartialView("AddEditExpenseDefinition", null);

        }

        [HttpPost]
        public IActionResult AddexpenseDefinition(ExpenseDefinition expenseDefinition)
        {
            IResult result;
            if (expenseDefinition.Id == null || expenseDefinition.Id <= 0)
                result = _expenseDefinitionService.Add(expenseDefinition);
            else
                result = _expenseDefinitionService.Update(expenseDefinition);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeleteExpenseDefinitionById(int id)
        {
            var _expenseDefinitionResult = _expenseDefinitionService.GetById(id);

            var result = _expenseDefinitionService.Delete(_expenseDefinitionResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }
    }
}
