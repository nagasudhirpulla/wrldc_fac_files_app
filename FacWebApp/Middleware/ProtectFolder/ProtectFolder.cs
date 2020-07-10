using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace FacWebApp.Middleware.ProtectFolder
{
    public class ProtectFolder
    {
        private readonly RequestDelegate _next;
        private readonly PathString _path;
        private readonly string _policyName;

        public ProtectFolder(RequestDelegate next, ProtectFolderOptions options)
        {
            _next = next;
            _path = options.Path;
            _policyName = options.PolicyName;
        }

        public async Task Invoke(HttpContext httpContext,
                                 IAuthorizationService authorizationService)
        {
            if (httpContext.Request.Path.StartsWithSegments(_path))
            {
                var authorized = await authorizationService.AuthorizeAsync(
                                    httpContext.User, null, _policyName);
                if (!authorized.Succeeded)
                {
                    httpContext.Response.Redirect($"/Identity/Account/Login?returnUrl={_path}");
                }
            }

            await _next(httpContext);
        }
    }
}
