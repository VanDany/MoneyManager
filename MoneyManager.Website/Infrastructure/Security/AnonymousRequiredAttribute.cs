using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MoneyManager.Website.Infrastructure.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Infrastructure.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AnonymousRequiredAttribute : TypeFilterAttribute
    {
        public AnonymousRequiredAttribute() : base(typeof(AuthRequiredFilter))
        {

        }
        private class AuthRequiredFilter : IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                ISessionManager sessionManager = (ISessionManager)context.HttpContext.RequestServices.GetService(typeof(ISessionManager));

                if (sessionManager.User is not null)
                {
                    context.Result = new RedirectToActionResult("Index", "Category", null);
                }
            }
        }
    }
}
