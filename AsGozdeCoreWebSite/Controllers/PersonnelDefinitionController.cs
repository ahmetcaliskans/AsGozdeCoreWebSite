using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Controllers
{
    public class PersonnelDefinitionController : Controller
    {
        private IPersonnelDefinitionService _personnelDefinitionService;
        public PersonnelDefinitionController(IPersonnelDefinitionService personnelDefinitionService)
        {
            _personnelDefinitionService = personnelDefinitionService;
        }
        public IActionResult Index()
        {
            RoleOperation roleOperation = new RoleOperation("PersonnelDefinition.Show");
            roleOperation.fn_checkRole();
            var result = _personnelDefinitionService.GetListWithDetails(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value));
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult GetPersonnelDefinitionById(int id)
        {
            var result = _personnelDefinitionService.GetById(id);
            if (result.Success)
            {
                return PartialView("AddEditPersonnelDefinition", result.Data);
            }

            return PartialView("AddEditPersonnelDefinition", null);

        }

        [HttpPost]
        public IActionResult AddPersonnelDefinition(PersonnelDefinition personnelDefinition)
        {
            IResult result;
            personnelDefinition.OfficeId = Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("primarygroupsid")).FirstOrDefault().Value);
            personnelDefinition.BranchId = personnelDefinition.BranchId == 0 || !personnelDefinition.IsMasterTrainer ? null : personnelDefinition.BranchId;
            if (personnelDefinition.Id == null || personnelDefinition.Id <= 0)
                result = _personnelDefinitionService.Add(personnelDefinition);
            else
                result = _personnelDefinitionService.Update(personnelDefinition);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeletePersonnelDefinitionById(int id)
        {
            var _personnelDefinitionResult = _personnelDefinitionService.GetById(id);

            var result = _personnelDefinitionService.Delete(_personnelDefinitionResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }
    }
}
