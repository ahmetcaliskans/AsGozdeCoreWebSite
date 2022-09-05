using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Components
{
    public class RoleTypeList :ViewComponent
    {
        private IRoleTypeService _roleTypeService;
        public RoleTypeList(IRoleTypeService roleTypeService)
        {
            _roleTypeService = roleTypeService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int roleTypeId)
        {
            dynamic dynamicResult = new System.Dynamic.ExpandoObject();
            dynamicResult.RoleTypes = new List<RoleType>();
            dynamicResult.SelectedId = roleTypeId;
            var result = _roleTypeService.GetList();
            if (result.Success)
            {
                dynamicResult.RoleTypes = result.Data.Where(x=>User.Identity.Name=="admin" || x.Name!="admin").ToList();
                return View("RoleTypeList", dynamicResult);
            }

            return View("RoleTypeList", dynamicResult);
        }
    }
}
