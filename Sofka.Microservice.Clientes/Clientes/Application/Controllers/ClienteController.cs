using Microsoft.AspNetCore.Mvc;
using Sofka.Microservice.Clientes.ApplicationSettings;
using Sofka.Microservice.Clientes.Clientes.Application.Commands;
using Sofka.Microservice.Clientes.Clientes.Application.DTOs;
using Sofka.Microservice.Clientes.Clientes.Application.Queries;
using Sofka.Microservice.Clientes.Clientes.Domain.Models;

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
        response.Data = await Mediator.Send(new ObtenerClientesQuery());
        
        return Ok(response);
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
        await Mediator.Send(command);
        
        return CreatedAtAction(nameof(CrearCliente), response);
    }

    [HttpDelete]
    public async Task<IActionResult> EliminarClienteAsync([FromQuery] EliminarClienteCommand eliminarClienteCommand)
    {
        var response = new SuccessResponse<string>("Cliente eliminado exitosamente");
        await Mediator.Send(eliminarClienteCommand);

        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> ActualizarClienteAsync([FromBody] ActualizarClienteCommand actualizarClienteCommand)
    {
        var response = new SuccessResponse<ClienteCompleto>("Cliente actualizado exitosamente");
        response.Data = await Mediator.Send(actualizarClienteCommand);
        
        return Ok(response);
    }
}
