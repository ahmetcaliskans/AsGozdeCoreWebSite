using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Controllers
{
    public class SessionController : Controller
    {
        private ISessionService _SessionService;

        public SessionController(ISessionService SessionService)
        {
            _SessionService = SessionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var result = _SessionService.GetList();
            //if (result.Success)
            //{
            //    return Ok(result.Data);
            //}

            //return BadRequest(result.Message);

            var result = _SessionService.GetList();
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult GetSessionById(int id)
        {
            var result = _SessionService.GetById(id);
            if (result.Success)
            {
                return PartialView("AddEditSession", result.Data);
            }

            return PartialView("AddEditSession", null);

        }

        [HttpPost]
        public IActionResult AddSession(Session Session)
        {
            var activeOldSession = _SessionService.GetActive();
            if (Session.Active && activeOldSession.Data != null)
            {
                activeOldSession.Data.Active = false;
                _SessionService.Update(activeOldSession.Data);
            }

            IResult result;
            if (Session.Id == null || Session.Id <= 0)
            {
                result = _SessionService.Add(Session);                
            }                
            else
            {
                result = _SessionService.Update(Session);
            }
                

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeleteSessionById(int id)
        {
            var _SessionResult = _SessionService.GetById(id);

            var result = _SessionService.Delete(_SessionResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }
    }
}
