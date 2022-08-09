using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Components
{
    public class ExpenseDefinitionListViewComponent : ViewComponent
    {
        private IExpenseDefinitionService _expenseDefinitionService;

        public ExpenseDefinitionListViewComponent(IExpenseDefinitionService expenseDefinitionService)
        {
            _expenseDefinitionService = expenseDefinitionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int expenseDefinitionId)
        {
            var result = _expenseDefinitionService.GetList();
            dynamic mymodel = new System.Dynamic.ExpandoObject();
            mymodel.ExpenseDefinition = result.Data.OrderBy(x => x.Name).ToList();
            mymodel.SelectedId = expenseDefinitionId == null ? 0 : expenseDefinitionId;

            return View("ExpenseDefinitionList", mymodel);
        }
    }
}
