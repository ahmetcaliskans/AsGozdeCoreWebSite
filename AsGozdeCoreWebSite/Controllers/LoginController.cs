using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public IActionResult Index()
        {
            var result = _officeService.GetList();
            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password, int officeId)
        {
            UserForLoginDto userForLoginDto = new UserForLoginDto{ UserName = username, Password = password, OfficeId = officeId };
            var userToLogin = _authService.Login(userForLoginDto);
            if (userToLogin.Success)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.UserData,userToLogin.Data.UserName)
                };

                //var userIdentity = new ClaimsIdentity(claims,"a");

                var officeResult = _officeService.GetById(officeId);
                
                var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userToLogin.Data.UserName), }, "a", ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                identity.AddClaim(new Claim(ClaimTypes.GivenName, userToLogin.Data.FirstName==null ? "" : userToLogin.Data.FirstName));
                identity.AddClaim(new Claim(ClaimTypes.Surname, userToLogin.Data.LastName==null ? "" : userToLogin.Data.LastName));
                identity.AddClaim(new Claim(ClaimTypes.GroupSid, (officeResult!=null && officeResult.Data!=null) ? officeResult.Data.Name : ""));
                identity.AddClaim(new Claim(ClaimTypes.PrimaryGroupSid, userForLoginDto.OfficeId.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.StateOrProvince, userToLogin.Data.Title==null ? "" : userToLogin.Data.Title));
                
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);

                return Json("Success");

            }
            else
                return Json(userToLogin.Message);
            
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Login");

        }
    }
}
