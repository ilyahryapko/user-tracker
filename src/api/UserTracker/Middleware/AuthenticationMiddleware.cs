using System;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace UserTracker.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration configuration;

        public AuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            this.next = next;
            this.configuration = configuration;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var userId = httpContext.Request.Cookies["UserId"];
            if (string.IsNullOrEmpty(userId))
            {
                userId = Guid.NewGuid().ToString();
            }
            
            var domain = new Uri(configuration.GetValue<string>("App:FrontendUrl")).Host;

            httpContext.Response.Cookies.Append("UserId", userId, new CookieOptions()
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,
                Domain = domain
            });

            var principal = new Principal(new GenericIdentity(userId), new string[] { });
            Thread.CurrentPrincipal = principal;
            httpContext.User = principal;

            await next(httpContext);
        }
    }
    
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthenticationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}