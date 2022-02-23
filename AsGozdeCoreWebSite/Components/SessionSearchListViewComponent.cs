using Business.Abstract;
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

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _sessionService.GetList();
            return View("SessionSearchList", result.Data.OrderByDescending(x => x.Year).ThenByDescending(x => x.Sequence).ToList());
        }
    }
}
