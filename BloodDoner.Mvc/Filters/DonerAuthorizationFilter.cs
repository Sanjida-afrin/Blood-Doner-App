using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BloodDoner.Mvc.Filters
{
    public class DonerAuthorizationFilter : IAsyncAuthorizationFilter
    {
        public DonerAuthorizationFilter()
        {
        }
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity?.IsAuthenticated ?? true)
            {
                // User is not authenticated
                context.Result = new UnauthorizedResult();
                return Task.CompletedTask;
            }

            if (!user.IsInRole(""))
            {
                // User is authenticated but not authorized
                context.Result = new ForbidResult();
            }
            return Task.CompletedTask;
        }
    }
}