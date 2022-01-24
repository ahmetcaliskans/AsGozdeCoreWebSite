using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService UserService)
        {
            _userService = UserService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _userService.GetList();
            return View(result.Data);
        }


        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return PartialView("AddEditUser", result.Data);
            }

            return PartialView("AddEditUser", null);

        }

        [HttpPost]
        public IActionResult AddUser(User User)
        {
            IResult result;
            if (User.UserId == null || User.UserId <= 0)
                result = _userService.Add(User);
            else
            {
                var UserPass = _userService.GetById(User.UserId).Data.PasswordHash;
                User.PasswordHash = UserPass;
                result = _userService.Update(User);
            }
                

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }

        [HttpPost]
        public IActionResult DeleteUserById(int id)
        {
            var _UserResult = _userService.GetById(id);

            var result = _userService.Delete(_UserResult.Data);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);


        }
    }
}
