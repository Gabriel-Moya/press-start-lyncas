using PressStartApi.Interfaces;
using System.Net.Http.Headers;
using System.Text;

namespace PressStartApi.Middleware
{
    public class BasicAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public BasicAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAuthenticateService authenticateService)
        {
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
                var email = credentials[0];
                var password = credentials[1];

                // authenticate credentials with user service and attach user to http context
                DTO.Request.LoginDTO loginDTO = new DTO.Request.LoginDTO { Email = email, Password = password };
                context.Items["User"] = await authenticateService.Authenticate(loginDTO);
            }
            catch
            {
                // do nothing if invalid auth header
                // user is not attached to context so request won't have access to secure routes
            }

            await _next(context);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class BasicAuthMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseBasicAuthMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<BasicAuthMiddleware>();
    //    }
    //}
}
