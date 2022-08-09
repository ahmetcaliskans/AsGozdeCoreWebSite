using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Components
{
    public class ExpenseDefinitionSearchListViewComponent : ViewComponent
    {
        private IExpenseDefinitionService _expenseDefinitionService;

        public ExpenseDefinitionSearchListViewComponent(IExpenseDefinitionService expenseDefinitionService)
        {
            _expenseDefinitionService = expenseDefinitionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            dynamic dynamicResult = new System.Dynamic.ExpandoObject();
            dynamicResult.ExpenseDefinitions = new List<ExpenseDefinition>();
            dynamicResult.Id = id;
            var result = _expenseDefinitionService.GetList();
            if (result.Success)
            {
                dynamicResult.ExpenseDefinitions = result.Data.OrderByDescending(x => x.Name).ToList();
                return View("ExpenseDefinitionSearchList", dynamicResult);
            }

            return View("ExpenseDefinitionSearchList", dynamicResult);

        }
    }
}
