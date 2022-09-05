using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Controllers
{
    public class RoleFormDefinitionController : Controller
    {
        private IRoleFormDefinitionService _roleFormDefinitionService;
        public RoleFormDefinitionController(IRoleFormDefinitionService roleFormDefinitionService)
        {
            _roleFormDefinitionService = roleFormDefinitionService;
        }
        public IActionResult Index()
        {
            RoleOperation roleOperation = new RoleOperation("RoleFormDefinition.Show");
            roleOperation.fn_checkRole();
            var result = _roleFormDefinitionService.GetList();
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult GetRoleFormDefinitionById(int id)
        {
            var result = _roleFormDefinitionService.GetById(id);
            if (result.Success)
            {
                return PartialView("AddEditRoleFormDefinition", result.Data);
            }

            return PartialView("AddEditRoleFormDefinition", null);

        }

        [HttpPost]
        public IActionResult AddRoleFormDefinition(RoleFormDefinition roleFormDefinition)
        {

            IResult result;
            if (roleFormDefinition.Id == null || roleFormDefinition.Id <= 0)
            {
                result = _roleFormDefinitionService.Add(roleFormDefinition);
            }
            else
            {
                result = _roleFormDefinitionService.Update(roleFormDefinition);
            }


            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeleteRoleFormDefinitionById(int id)
        {
            var _roleFormDefinitionResult = _roleFormDefinitionService.GetById(id);

            var result = _roleFormDefinitionService.Delete(_roleFormDefinitionResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);

        }
    }
}
