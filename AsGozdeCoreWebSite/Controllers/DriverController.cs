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
    public class DriverController : Controller
    {
        private IDriverInformationService _driverInformationService;

        public DriverController (IDriverInformationService driverInformationService)
        {
            _driverInformationService = driverInformationService;
        }

        public IActionResult Index()
        {
            var result = _driverInformationService.GetListWithDetails(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value));
            if (result != null)
            {
                return View(result.Data.OrderByDescending(x=> x.Session.Year).ThenByDescending(x=>x.Session.Sequence).ThenByDescending(x=>x.Id).ToList());
            }

            return View();
        }


        [HttpGet]
        public IActionResult GetDriverByIdWithDetails(int id)
        {
            var result = _driverInformationService.GetByIdWithDetails(id);
            if (result.Success)
            {
                return View("AddEditDriver", result.Data);
            }

            return View("AddEditDriver", result.Data);

        }

        [HttpPost]
        public IActionResult AddDriver(DriverInformation driverInformation)
        {
            IResult result;
            driverInformation.OfficeId = Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value);
            if (driverInformation.Id == null || driverInformation.Id <= 0)
                result = _driverInformationService.Add(driverInformation);
            else
                result = _driverInformationService.Update(driverInformation);



            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeleteDriverById(int id)
        {
            var _driverResult = _driverInformationService.GetById(id);

            var result = _driverInformationService.Delete(_driverResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

    }
}
