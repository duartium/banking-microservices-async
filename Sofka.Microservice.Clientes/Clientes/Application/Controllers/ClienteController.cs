using Microsoft.AspNetCore.Mvc;
using Sofka.Microservice.Clientes.Clientes.Application.Commands;
using Sofka.Microservice.Clientes.Clientes.Application.DTOs;
using Sofka.Microservice.Clientes.Clientes.Application.Queries;

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

    /// <summary>
    /// Crea un nuevo cliente.
    /// </summary>
    /// <param name="command">Datos del cliente a crear</param>
    /// <returns>Respuesta con la confirmación de creación</returns>
    [HttpPost]
    public async Task<IActionResult> CrearCliente([FromBody] CrearClienteCommand command)
    {
        var response = new SuccessResponse<string>("Cliente creado exitosamente");

        try
        {
            await Mediator.Send(command);
            return CreatedAtAction(nameof(CrearCliente), response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            response.Update(false, ex.Message, "");
            return StatusCode(500, response);
        }
    }
}
