using System.Security.Claims;

namespace CartService.API.CustomMiddleware
{
    public class TokenLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<TokenLoggingMiddleware> logger)
        {
            if (context.User.Identity is ClaimsIdentity identity)
            {
                var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                _ = identity.IsAuthenticated
                    ? context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "")
                    : string.Empty;

                logger.LogInformation($"User: {identity.Name} with token: {token} called {context.Request.Path}");
            }

            await _next(context);
        }
    }
}
