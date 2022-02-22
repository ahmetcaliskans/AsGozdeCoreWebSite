using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Components
{
    public class BranchListViewComponent : ViewComponent
    {
        private IBranchService _branchService;

        public BranchListViewComponent( IBranchService branchService)
        {
            _branchService = branchService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int branchId)
        {
            var result = _branchService.GetList();
            dynamic mymodel = new System.Dynamic.ExpandoObject();
            mymodel.Branch = result.Data;
            mymodel.SelectedId = branchId == null ? 0 : branchId;
            //return await Task.FromResult((IViewComponentResult)View("GetBranchList", result.Data));
            return View("BranchList", mymodel);
        }
    }
}
