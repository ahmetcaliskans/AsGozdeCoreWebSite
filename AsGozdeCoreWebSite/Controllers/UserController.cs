using AsGozdeCoreWebSite.Models.PermissionAuthorization;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Dtos;
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
        private IAuthService _authService;

        public UserController(IUserService UserService, IAuthService authService)
        {
            _userService = UserService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            RoleOperation roleOperation = new RoleOperation("User.Show");
            roleOperation.fn_checkRole();

            List<UserForRegisterDto> users;

            if (User.Identity.Name!="admin")
                users = _userService.GetListWithDetails().Data.Where(x=>x.UserName!="admin").ToList();
            else
                users = _userService.GetListWithDetails().Data;

            return View(users);
        }

        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                if (User.Identity.Name!="admin" &&  result.Data!=null && result.Data.UserName=="admin")
                {
                    return PartialView("AddEditUser", new UserForRegisterDto());
                }
                else
                    return PartialView("AddEditUser", result.Data);
            }

            return PartialView("AddEditUser", result.Data);

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
            if (_UserResult.Data.UserName!="admin")
            {
                var result = _userService.Delete(_UserResult.Data);
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                    return BadRequest(result.Message);
            }
            else    
                return BadRequest(Messages.CannotDeleteAdmin);


        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(string oldPassword, string newPassword, string againNewPassword)
        {
            var userResult = _userService.GetByUserName(User.Identity.Name);
            if (userResult.Data!=null)
            {
                if (SecuredOperation.DeEncryptAES(userResult.Data.PasswordHash, Messages.SecurityKey) != oldPassword)
                {
                    return BadRequest(Messages.PasswordDoesnotMatch);
                }

                if (newPassword != againNewPassword)
                {
                    return BadRequest(Messages.PasswordDoesnotMatchWithAgain);
                }

                var result = _authService.ChangePass(userResult.Data, newPassword);
                return Ok(result.Message);
                
            }

            return View();
        }
    }
}
