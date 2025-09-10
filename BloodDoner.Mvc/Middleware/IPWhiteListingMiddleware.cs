using BloodDoner.Mvc.Configuration;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;

namespace BloodDoner.Mvc.Middleware
{
    public class IPWhiteListingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly List<string> _allowedIPs;
        private EmailSettings _mailSettings;

        public IPWhiteListingMiddleware(RequestDelegate next, IConfiguration configuration, IOptionsMonitor<EmailSettings>monitor)
        {
            _next = next;
            _allowedIPs = configuration.GetSection("AllowedIPs").Get<List<string>>() ?? new List<string>();
            var mailSettings = configuration.GetSection("MailSettings").Get<EmailSettings>();
            monitor.OnChange(settings=> _mailSettings = settings);
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var remoteIp = context.Connection.RemoteIpAddress?.ToString();
            if (remoteIp == null|| !_allowedIPs.Contains(remoteIp))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Forbidden: Ypor IP is not allowed");
                return;
            }
            await _next(context);
        }
    }
}
