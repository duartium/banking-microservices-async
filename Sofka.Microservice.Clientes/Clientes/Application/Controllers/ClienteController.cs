using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sofka.Microservice.Clientes.Clientes.Application.Commands;
using Sofka.Microservice.Clientes.Clientes.Application.DTOs;
using Sofka.Microservice.Clientes.Clientes.Application.Queries;
using Sofka.Microservice.Clientes.Clientes.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
            response.Update(false, ex.Message);
            return StatusCode(500, response);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> EliminarClienteAsync([FromQuery] EliminarClienteCommand eliminarClienteCommand)
    {
        var response = new SuccessResponse<string>("Cliente eliminado exitosamente");

        try
        {
            await Mediator.Send(eliminarClienteCommand);

            return NoContent();
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            response.Update(false, ex.Message);
            return StatusCode(500, response);
        }
    }

    [HttpPut]
    public async Task<IActionResult> ActualizarClienteAsync([FromBody] ActualizarClienteCommand actualizarClienteCommand)
    {
        var response = new SuccessResponse<ClienteCompleto>("Cliente actualizado exitosamente");

        try
        {
            response.Data = await Mediator.Send(actualizarClienteCommand);
            return Ok(response);
        }
        catch (Exception ex)
        {
            Logger.LogError(ex.ToString());
            response.Update(false, ex.Message);
            return StatusCode(500, response);
        }
    }
}
