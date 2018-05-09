using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericWarehouseWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace GenericWarehouseWebsite.Authorization
{
    public class TAdminAuthorizationHandler
        : AuthorizationHandler<OperationAuthorizationRequirement, Tool>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            Tool resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            // Administrators can do anything.
            if (context.User.IsInRole(Constants.ContactAdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
