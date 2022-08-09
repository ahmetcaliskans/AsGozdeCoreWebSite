using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AsGozdeCoreWebSite.Controllers
{
    public class FixtureDefinitionController : Controller
    {
        private IFixtureDefinitionService _fixtureDefinitionService;
        public FixtureDefinitionController(IFixtureDefinitionService fixtureDefinitionService)
        {
            _fixtureDefinitionService = fixtureDefinitionService;
        }
        public IActionResult Index()
        {
            var result = _fixtureDefinitionService.GetList();
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult GetFixtureDefinitionById(int id)
        {
            var result = _fixtureDefinitionService.GetById(id);
            if (result.Success)
            {
                return PartialView("AddEditFixtureDefinition", result.Data);
            }

            return PartialView("AddEditFixtureDefinition", null);

        }

        [HttpPost]
        public IActionResult AddfixtureDefinition(FixtureDefinition fixtureDefinition)
        {
            IResult result;
            if (fixtureDefinition.Id == null || fixtureDefinition.Id <= 0)
                result = _fixtureDefinitionService.Add(fixtureDefinition);
            else
                result = _fixtureDefinitionService.Update(fixtureDefinition);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeleteFixtureDefinitionById(int id)
        {
            var _fixtureDefinitionResult = _fixtureDefinitionService.GetById(id);

            var result = _fixtureDefinitionService.Delete(_fixtureDefinitionResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }
    }
}
