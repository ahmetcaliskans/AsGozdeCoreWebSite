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
    public class BranchController : Controller
    {
        IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _branchService.GetList();
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult GetBranchById(int id)
        {
            var result = _branchService.GetById(id);
            if (result.Success)
            {
                return PartialView("AddEditBranch", result.Data);
            }

            return PartialView("AddEditBranch", null);

        }

        [HttpPost]
        public IActionResult AddBranch(Branch branch)
        {
            IResult result;
            if (branch.Id == null || branch.Id <= 0)
                result = _branchService.Add(branch);
            else
                result = _branchService.Update(branch);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeleteBranchById(int id)
        {
            var _branchResult = _branchService.GetById(id);

            var result = _branchService.Delete(_branchResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }
    }
}
