using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Entities.Abstract;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using DataAccess.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    public class RoleOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        private Efsp_GetRoleDal efsp_GetRoleDal;

        public RoleOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            efsp_GetRoleDal = new Efsp_GetRoleDal();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            fn_checkRole();            
        }

        public void fn_checkRole()
        {
            string role = "";
            string message = "";
            if (_httpContextAccessor.HttpContext.User.Identity.Name != "admin")
            {
                var roleClaims = efsp_GetRoleDal.GetRolesByRoleTypeId(Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type.Contains("role")).FirstOrDefault().Value));
                if (roleClaims != null)
                {
                    foreach (var roleSplit in _roles)
                    {
                        string formName = roleSplit.Split('.')[0];
                        formName = formName.Contains("/") ? formName.Split('/')[0] : formName;
                        string formSubName = roleSplit.Split('.')[0].Contains("/") ? roleSplit.Split('.')[0].Split('/')[1] : formName;
                        role = roleSplit.Split('.')[1];
                        foreach (var roleClaim in roleClaims.Where(x => x.FormName == formName && (x.FormSubName == null || x.FormSubName == formSubName)))
                        {
                            if (roleClaim.GetType().GetProperty(role).Name == role)
                            {
                                if ((bool)roleClaim.GetType().GetProperty(role).GetValue(roleClaim, null))
                                {
                                    return;
                                }
                                else
                                {
                                    message += string.Format("{0} - {1} {2}", roleClaim.Description, convertRoleNameToLocalLanguage(role, roleClaim), Messages.AuthorizationDenied);
                                }
                            }
                        }

                    }
                    if (role == "Show")
                        _httpContextAccessor.HttpContext.Response.Redirect("/Home/RoleError?message=" + message);
                    else
                        throw new ApplicationException(message, null);

                }
                if (role == "Show")
                    _httpContextAccessor.HttpContext.Response.Redirect("/Home/RoleError?message=" + message);
                else
                    throw new ApplicationException(message, null);
            }
            else
            {
                return;
            }
        }

        private string convertRoleNameToLocalLanguage(string roleName, sp_GetRole role)
        {
            switch (roleName)
            {
                case "Show": return "Gösterme"; 
                case "Insert": return "Yeni Kayıt";
                case "Update": return "Güncelleme";
                case "Delete": return "Silme";
                case "Print": return "Yazdırma";
                case "Export": return "Dışarı Aktarma";
                case "SpecialRole1": return role.SpecialRole1Description;
                case "SpecialRole2": return role.SpecialRole2Description;
                case "SpecialRole3": return role.SpecialRole3Description;
                case "SpecialRole4": return role.SpecialRole4Description;
                case "SpecialRole5": return role.SpecialRole5Description;
                default: return "";
            }
        }
    }
}
