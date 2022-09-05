using AsGozdeCoreWebSite.Models;
using Business.Abstract;
using Core.Entities.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Controllers
{
    public class HomeController : Controller
    {         
        public static List<sp_GetRole> Roles;

        private readonly ILogger<HomeController> _logger;
        private Isp_GetRoleService _sp_GetRoleService;

        public HomeController(ILogger<HomeController> logger, Isp_GetRoleService sp_GetRoleService)
        {
            _logger = logger;
            _sp_GetRoleService = sp_GetRoleService;
        }

        public IActionResult Index()
        {
            var roleResult = _sp_GetRoleService.GetRolesByRoleTypeId(Convert.ToInt32(User.Claims.Where(x => x.Type.Contains("role")).FirstOrDefault().Value));
            if (roleResult!=null && roleResult.Data.Count>0)
            {
                Roles = roleResult.Data;
            }
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
        public IActionResult RoleError(string message)
        {
            return View(new RoleErrorViewModel { Message = message });
        }
    }
}
