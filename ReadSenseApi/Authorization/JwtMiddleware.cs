using ReadSenseApi.Services;

namespace ReadSenseApi.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService, IJwtUtils jwtUtils)
        {
            var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
            var jstClaims = jwtUtils.ValidateJwtToken(token);
            
            if (jstClaims != null)
            {
                int? userId = int.Parse(jstClaims.First(x => x.Type == "id").Value);
                int? deviceId = int.Parse(jstClaims.First(x => x.Type == "deviceId").Value);
                
                if (userId != null)
                {
                    // attach user & deviceId to context on successful jwt validation
                    context.Items["User"] = userService.GetById(userId.Value);
                    context.Items["DeviceId"] = deviceId;
                }
            }
            

            await _next(context);
        }
    }
}
