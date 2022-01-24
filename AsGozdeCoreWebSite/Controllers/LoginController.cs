using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {        
        private IOfficeService _officeService;
        private IAuthService _authService;

        public LoginController(IOfficeService officeService, IAuthService authService)
        {
            _officeService = officeService;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var result = _officeService.GetList();
            return View(result.Data);
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            UserForLoginDto userForLoginDto = new UserForLoginDto{ UserName = username, Password = password, OfficeName = "" };
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return Json(userToLogin.Message);
            }

            return Json("Success");
            
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Login");

        }
    }
}
