using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Product.Api.Middlewares
{
    public class ExceptionHandler(ILogger<ExceptionHandler> logger) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            var exceptionMessage = exception.Message;

            logger.LogError(
                "Error Message: {exceptionMessage}, Time of occurrence {time}",
                exceptionMessage, DateTime.UtcNow);

            var problemDetails = new ProblemDetails
            {
                Status = httpContext.Response.StatusCode,
                Type = exception.GetType().Name,
                Title = "An unhandled error occurred",
                Detail = exception.Message,
                Extensions =
                {
                    ["traceId"] = Activity.Current?.Id ?? httpContext.TraceIdentifier
                },
                Instance = httpContext.Request.Path,
            };
            await httpContext
                .Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
