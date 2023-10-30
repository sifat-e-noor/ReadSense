using System.Diagnostics;
using System.Text;

namespace ReadSenseApi.Helpers
{
    public class DefaultPageMiddleware
    {
        private readonly RequestDelegate _next;

        public DefaultPageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            if (context != null && (string.IsNullOrEmpty(context.Request.Path.Value) || context.Request.Path.Value == "/"))
            {
                context.Response.ContentType = "text/plain";

                var _startTimestamp = Process.GetCurrentProcess().StartTime.ToUniversalTime();

                var sb = new StringBuilder()
                    .AppendLine("ReadSense API")
                    .AppendLine()
                    .AppendLine("Swagger UI: /swagger")
                    .AppendLine()
                    .AppendLine($"Uptime......: {DateTime.UtcNow.Subtract(_startTimestamp)}")
                    .AppendLine($"Started.....: {_startTimestamp:yyyy-MM-dd HH:mm:ssK}");


                await context.Response.WriteAsync(sb.ToString());
            }
            else
            {
                await _next(context!);
            }
        }
    }
}
