using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using MyApp.Models.Common;
namespace MyApp.Models
{
    public class CustomAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Check if the user is authenticated
            var isAuthenticated = !string.IsNullOrEmpty(SessionManager.UserId);


            // If not authenticated, redirect to Login page
            if (!isAuthenticated)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Login" },
                    { "action", "Login" }
                });
            }
        }
    }
}
