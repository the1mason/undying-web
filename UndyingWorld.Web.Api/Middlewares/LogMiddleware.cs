namespace UndyingWorld.Web.Api.Middlewares;
public class LogMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<LogMiddleware> _logger;


    public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        string user = httpContext.User.Identity.IsAuthenticated ? httpContext.User.Identity.Name + " " : "";
        _logger.LogInformation($"{httpContext.Request.Headers["X-Forwarded-For"]} {user}-> {httpContext.Request.Path}");
        await this._next(httpContext);
    }
}

public static class LogMiddlewareExtensions
{
    public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<LogMiddleware>();
    }
}
