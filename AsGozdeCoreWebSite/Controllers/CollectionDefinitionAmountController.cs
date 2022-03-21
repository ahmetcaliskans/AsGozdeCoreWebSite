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
    public class CollectionDefinitionAmountController : Controller
    {
        private ICollectionDefinitionAmountService _collectionDefinitionAmountService;
        public CollectionDefinitionAmountController(ICollectionDefinitionAmountService collectionDefinitionAmountService)
        {
            _collectionDefinitionAmountService = collectionDefinitionAmountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _collectionDefinitionAmountService.GetListWithDetails();
            if (result.Success)
            {
                return View(result.Data);
            }

            return View();
        }

        [HttpGet]
        public IActionResult GetCollectionDefinitionAmountById(int id)
        {
            var result = _collectionDefinitionAmountService.GetById(id);
            if (result.Success)
            {
                return PartialView("AddEditCollectionDefinitionAmount", result.Data);
            }

            return PartialView("AddEditCollectionDefinitionAmount", null);

        }

        [HttpPost]
        public IActionResult AddcollectionDefinitionAmount(CollectionDefinitionAmount collectionDefinitionAmount)
        {
            collectionDefinitionAmount.UpdatedDateTime = DateTime.Now;
            collectionDefinitionAmount.UpdatedUserName = User.Identity.Name;

            IResult result;
            if (collectionDefinitionAmount.Id == null || collectionDefinitionAmount.Id <= 0)
            {
                collectionDefinitionAmount.AddedDateTime = collectionDefinitionAmount.UpdatedDateTime;
                collectionDefinitionAmount.AddedUserName = collectionDefinitionAmount.UpdatedUserName;
                result = _collectionDefinitionAmountService.Add(collectionDefinitionAmount);
            }                
            else
            {
                var collectionDefinitionAmountFromDB = _collectionDefinitionAmountService.GetById(collectionDefinitionAmount.Id).Data;
                collectionDefinitionAmount.AddedDateTime = collectionDefinitionAmountFromDB.AddedDateTime;
                collectionDefinitionAmount.AddedUserName = collectionDefinitionAmountFromDB.AddedUserName;
                result = _collectionDefinitionAmountService.Update(collectionDefinitionAmount);
            }
                

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeleteCollectionDefinitionAmountById(int id)
        {
            var _collectionDefinitionAmountResult = _collectionDefinitionAmountService.GetById(id);

            var result = _collectionDefinitionAmountService.Delete(_collectionDefinitionAmountResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }
    }
}
