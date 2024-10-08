using System.Text.Json.Serialization;

namespace Sofka.Architecture.Microservices.Common.Models;

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
        Message = "Petición exitosa";
    }
}


public class ErrorResponse<T> : ApiResponse<T>
{
    [JsonPropertyName("error_code")]
    public string ErrorCode { get; set; }
}
