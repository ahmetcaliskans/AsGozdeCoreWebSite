using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Components
{
    public class OfficeListViewComponent : ViewComponent
    {
        private IUserService _userService;
        private IOfficeService _officeService;

        public OfficeListViewComponent(IUserService UserService, IOfficeService officeService)
        {
            _userService = UserService;
            _officeService = officeService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int officeId)
        {
            var result = _officeService.GetList();
            dynamic mymodel = new System.Dynamic.ExpandoObject();            
            mymodel.Office = result.Data;
            var userOfficeName = result.Data.Where(x => x.Id == officeId);
            mymodel.UserOfficeName = (userOfficeName==null || userOfficeName.Count()==0) ? "" : userOfficeName.FirstOrDefault().Name;
            //return await Task.FromResult((IViewComponentResult)View("GetOfficeList", result.Data));
            return View("OfficeList",mymodel);
        }
    }
}
