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
    public class CollectionDefinitionController : Controller
    {
        ICollectionDefinitionService _collectionDefinitionService;

        public CollectionDefinitionController(ICollectionDefinitionService collectionDefinitionService)
        {
            _collectionDefinitionService = collectionDefinitionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _collectionDefinitionService.GetList();
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult GetCollectionDefinitionById(int id)
        {
            var result = _collectionDefinitionService.GetById(id);
            if (result.Success)
            {
                return PartialView("AddEditCollectionDefinition", result.Data);
            }

            return PartialView("AddEditCollectionDefinition", null);

        }

        [HttpPost]
        public IActionResult AddcollectionDefinition(CollectionDefinition collectionDefinition)
        {
            IResult result;
            if (collectionDefinition.Id == null || collectionDefinition.Id <= 0)
                result = _collectionDefinitionService.Add(collectionDefinition);
            else
                result = _collectionDefinitionService.Update(collectionDefinition);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeleteCollectionDefinitionById(int id)
        {
            var _collectionDefinitionResult = _collectionDefinitionService.GetById(id);

            var result = _collectionDefinitionService.Delete(_collectionDefinitionResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }
    }
}
