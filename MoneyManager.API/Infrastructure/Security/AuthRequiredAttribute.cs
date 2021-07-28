using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.API.Infrastructure.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthRequiredAttribute : TypeFilterAttribute
    {
        public AuthRequiredAttribute() : base(typeof(AuthRequiredFilter))
        {
        }
        private class AuthRequiredFilter : IAuthorizationFilter
        {
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                ITokenRepository tokenService = (ITokenRepository)context.HttpContext.RequestServices.GetService(typeof(ITokenRepository));

                context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues authorizations);
                string token = authorizations.SingleOrDefault(authorization => authorization.StartsWith("Bearer "));

                if (token is null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                TokenUser user = tokenService.ValidateToken(token);

                if (user is null)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                context.RouteData.Values["userId"] = user.Id;
            }
        }
    }
}
