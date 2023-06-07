using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Components
{
    public class BranchSearchListViewComponent : ViewComponent
    {
        private IBranchService _branchService;

        public BranchSearchListViewComponent(IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            dynamic dynamicResult = new System.Dynamic.ExpandoObject();
            dynamicResult.Branchs = new List<Branch>();
            dynamicResult.Id = id;
            var result = _branchService.GetList();
            if (result.Success)
            {
                dynamicResult.Branchs = result.Data.ToList();
                return View("BranchSearchList", dynamicResult);
            }

            return View("BranchSearchList", dynamicResult);

        }
    }
}
