using Azure;
using Microsoft.AspNetCore.Mvc;
using Sofka.Microservice.Clientes.Clientes.Application.DTOs;
using Sofka.Microservice.Clientes.Clientes.Application.Queries;
using Sofka.Architecture.Microservices.Common.Models;

namespace Sofka.Microservice.Clientes.Clientes.Application.Controllers;

[Route("api/clientes")]
[ApiController]
public class ClienteController : BaseApiController<ClienteController>
{

    /// <summary>
    /// Obtiene una lista de todos los clientes activos
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> ObtenerClientes()
    {
        var response = new SuccessResponse<ClienteDto[]>();
        try
        {
            var query = new ObtenerClientesQuery();
            response.Data = await Mediator.Send(query);
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            response.Update(false, ex.Message, []);
            return StatusCode(500, response);
        }
    }
}
