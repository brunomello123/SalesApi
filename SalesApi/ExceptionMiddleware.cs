using SalesApi.Domain.Exceptions;

namespace SalesApi;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (BusinessException ex)
        {
            _logger.LogError(ex, "A business exception occurred.");

            var response = httpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)ex.StatusCode;

            var result = new
            {
                type = ex.ErrorType, 
                error = ex.Message,
                detail = ex.Detail
            };

            await response.WriteAsJsonAsync(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred.");

            var response = httpContext.Response;
            response.ContentType = "application/json";
            response.StatusCode = StatusCodes.Status500InternalServerError;

            var result = new
            {
                type = StatusCodes.Status500InternalServerError.ToString(),
                error = "An unexpected error occurred.",
                detail = ex.Message
            };

            await response.WriteAsJsonAsync(result);
        }
    }
}