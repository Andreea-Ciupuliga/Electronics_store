using System;
using System.Collections.Generic;
using Electronics_store.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Electronics_store.Utilities.Atttributes
{
    public class AuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ICollection<Role> _roles;

        public AuthorizationAttribute(params Role[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //aici ne facem un obiect la care ii punem un mesaj si un status code
            var unauthorizedStatusCodeObject =
                new JsonResult(new
                    {
                        Message = "Unauthorized"
                    }) 
                    {StatusCode = StatusCodes.Status401Unauthorized};

            //poate nu e neaparat necesar sa verific rolurile; unele endpointuri au nevoie de autorizare
            if (_roles == null)
            {
                context.Result = unauthorizedStatusCodeObject;
            }

            var user = (User) context.HttpContext.Items["User"];
            if (user == null || !_roles.Contains(user.Role))
            {
                context.Result = unauthorizedStatusCodeObject;
            }
        }
    }
}