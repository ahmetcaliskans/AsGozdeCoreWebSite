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
    public class RoleTypeController : Controller
    {
        private IRoleTypeService _roleTypeService;
        public RoleTypeController(IRoleTypeService roleTypeService)
        {
            _roleTypeService = roleTypeService;
        }
        public IActionResult Index()
        {
            RoleOperation roleOperation = new RoleOperation("RoleType.Show");
            roleOperation.fn_checkRole();
            var result = _roleTypeService.GetList();
            return View(result.Data.Where(x => User.Identity.Name == "admin" || x.Name != "admin").ToList());
        }

        [HttpGet]
        public IActionResult GetRoleTypeById(int id)
        {
            var result = _roleTypeService.GetById(id);
            if (result.Success)
            {
                return PartialView("AddEditRoleType", result.Data);
            }

            return PartialView("AddEditRoleType", null);

        }

        [HttpPost]
        public IActionResult AddRoleType(RoleType roleType)
        {        

            IResult result;
            if (roleType.Id == null || roleType.Id <= 0)
            {
                result = _roleTypeService.Add(roleType);
            }
            else
            {
                result = _roleTypeService.Update(roleType);
            }


            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeleteRoleTypeById(int id)
        {
            var _roleTypeResult = _roleTypeService.GetById(id);

            var result = _roleTypeService.Delete(_roleTypeResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);

        }
    }
}
