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
    public class OfficeController : Controller
    {
        private IOfficeService _officeService;

        public OfficeController(IOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var result = _officeService.GetList();
            //if (result.Success)
            //{
            //    return Ok(result.Data);
            //}

            //return BadRequest(result.Message);

            var result = _officeService.GetList();
            return View(result.Data);
        }


        [HttpGet]
        public IActionResult GetOfficeById(int id)
        {
            var result =_officeService.GetById(id);
            if (result.Success)
            {
                return PartialView("AddEditOffice", result.Data);
            }

            return PartialView("AddEditOffice", null);

        }

        [HttpPost]
        public IActionResult AddOffice(Office office)
        {
            IResult result;
            if (office.Id==null || office.Id <= 0)
                result = _officeService.Add(office);
            else
                result = _officeService.Update(office);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeleteOfficeById(int id)
        {
            var _officeResult = _officeService.GetById(id);
            
            var result = _officeService.Delete(_officeResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }


    }
}
