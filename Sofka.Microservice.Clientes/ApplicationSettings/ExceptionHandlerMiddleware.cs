using FluentValidation;
using System.Net;
using System.Text.Json;

namespace Sofka.Microservice.Clientes.ApplicationSettings;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(
        RequestDelegate next, 
        ILogger<ExceptionHandlerMiddleware> logger)
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
        catch (ValidationException ex)
        {
            _logger.LogError(ex, "Ocurrió una excepción de validaciónes.");
            await HandleValidationExceptionAsync(httpContext, ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Ocuriró una excepción no controlada.");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var response = new ApiResponse<object>
        {
            Success = false,
            Message = "No cumple con las validaciones requeridas",
            Data = new { errors = exception.Errors.Select(e => e.ErrorMessage).ToArray() }
        };

        var result = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(result);
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new ApiResponse<object>
        {
            Success = false,
            Message = "Ocurrió un error inesperado",
        };

        var result = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(result);
    }
}
