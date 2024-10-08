using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace Sofka.Microservice.Clientes;

[Route("api/[controller]")]
[ApiController]
public class BaseApiController<T> : ControllerBase where T : BaseApiController<T>
{
    private IMediator? _mediator;
    private ILogger<T>? _logger;
    protected IMapper? _mapper;
    public IConfiguration? _configuration;

    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    protected ILogger<T> Logger => _logger ??= HttpContext.RequestServices.GetService<ILogger<T>>();
    protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>();
    protected IConfiguration Configuration => _configuration ??= HttpContext.RequestServices.GetService<IConfiguration>();
}


public class ApiResponse<T>
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonPropertyName("data")]
    public T Data { get; set; }

    public ApiResponse()
    {
    }

    public ApiResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }

    public void Setter(bool success, string message, T data)
    {
        Success = success;
        Message = message;
        Data = data;
    }

    /// <summary>
    /// Actualiza las propiedades de la respuesta standard
    /// </summary>
    public ApiResponse<T> Update(bool success, string message, T? data)
    {
        Success = success;
        Message = message;
        Data = data;

        return this;
    }

}
public class SuccessResponse<T> : ApiResponse<T>
{
    public SuccessResponse()
    {
        Success = true;
        Message = "Petición exitosa";
    }

    public SuccessResponse(string message)
    {
        Success = true;
        Message = message;
    }
}


public class ErrorResponse<T> : ApiResponse<T>
{
    [JsonPropertyName("error_code")]
    public string ErrorCode { get; set; }
}

public static class SofkaConstants
{
    public const string ESTADO_ACTIVO = "A";
    public const string ESTADO_INACTIVO = "I";
}