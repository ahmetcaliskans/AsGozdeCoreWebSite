using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Components
{
    public class SessionSearchListViewComponent : ViewComponent
    {
        private ISessionService _sessionService;

        public SessionSearchListViewComponent(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {            
            dynamic dynamicResult = new System.Dynamic.ExpandoObject();
            dynamicResult.Sessions = new List<Session>();
            dynamicResult.Id = id;
            var result = _sessionService.GetList();
            if (result.Success)
            {
                dynamicResult.Sessions = result.Data.OrderByDescending(x => x.Year).ThenByDescending(x => x.Sequence).ToList();
                return View("SessionSearchList", dynamicResult);
            }

            return View("SessionSearchList", dynamicResult);

        }
    }
}
