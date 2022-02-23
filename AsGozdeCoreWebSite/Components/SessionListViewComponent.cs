using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Components
{
    public class SessionListViewComponent : ViewComponent
    {
        private ISessionService _sessionService;

        public SessionListViewComponent(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int sessionId)
        {
            var result = _sessionService.GetList();
            dynamic mymodel = new System.Dynamic.ExpandoObject();
            mymodel.Session = result.Data.OrderByDescending(x=>x.Year).ThenByDescending(x=>x.Sequence).ToList();
            mymodel.SelectedId = sessionId == null ? 0 : sessionId;
            //return await Task.FromResult((IViewComponentResult)View("GetSessionList", result.Data));
            return View("SessionList", mymodel);
        }
    }
}
