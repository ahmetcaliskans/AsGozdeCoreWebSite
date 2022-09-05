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
    public class RoleController : Controller
    {
        private IRoleService _roleService;
        private Isp_GetRoleService _sp_GetRoleService;
        private IRoleTypeService _roleTypeService;
        public RoleController(IRoleService roleService, Isp_GetRoleService sp_GetRoleService, IRoleTypeService roleTypeService)
        {
            _roleService = roleService;
            _sp_GetRoleService = sp_GetRoleService;
            _roleTypeService = roleTypeService;
        }

        public IActionResult Index()
        {
            RoleOperation roleOperation = new RoleOperation("Role.Show");
            roleOperation.fn_checkRole();
            var result = _roleTypeService.GetList();
            if (ViewData["RoleTypeId"]==null)
            {
                ViewData["RoleTypeId"] = result.Data.FirstOrDefault().Id;
            }

            return View(result.Data);
        }

        public IActionResult GetRolesByRoleTypeId(int roleTypeId)
        {
            var result = _sp_GetRoleService.GetRolesByRoleTypeId(roleTypeId);
            return Ok(result.Data);
        }

        [HttpGet]
        public IActionResult GetRoleByRoleTypeIdAndRoleFormDefinitionId(int roleTypeId, int roleFormDefinitionId)
        {
            var result = _sp_GetRoleService.GetRoleByRoleTypeIdAndRoleFormDefinitionId(roleTypeId,roleFormDefinitionId);
            if (result.Success)
            {
                return PartialView("AddEditRole", result.Data);
            }

            return PartialView("AddEditRole", null);

        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {

            IResult result;
            if (role.Id == null || role.Id <= 0)
            {
                result = _roleService.Add(role);
            }
            else
            {
                result = _roleService.Update(role);
            }


            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeleteRoleById(int id)
        {
            var _roleResult = _roleService.GetById(id);

            var result = _roleService.Delete(_roleResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);

        }
    }
}
