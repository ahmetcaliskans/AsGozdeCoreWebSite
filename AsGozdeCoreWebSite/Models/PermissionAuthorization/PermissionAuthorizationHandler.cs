using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AsGozdeCoreWebSite.Models.PermissionAuthorization
{
    public class PermissionAuthorizationHandler : AttributeAuthorizationHandler<PermissionAuthorizationRequirement, PermissionAttribute>
    {
        bool success = false;
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionAuthorizationRequirement requirement, IEnumerable<PermissionAttribute> attributes)
        {
            if (attributes.Count()>0)
            {                
                foreach (var permissionAttribute in attributes)
                {
                    if (await AuthorizeAsync(context.User, permissionAttribute.Name))
                    {
                        success = true;
                        context.Succeed(requirement);
                        break;
                    }
                }

                if (!success)
                    return;
            }            

            context.Succeed(requirement);
        }


        private Task<bool> AuthorizeAsync(ClaimsPrincipal user, string permission)
        {            
            //Implement your custom user permission logic here
            Task<bool> t = Task.Run<bool>(() => {
                var roles = user.Claims.Where(x => x.Type.Contains("role") && x.Value==permission).FirstOrDefault();
                if (roles != null )
                    return true;
                else
                    return false;
                
            });

            return t;
            
        }
    }
}
