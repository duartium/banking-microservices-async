using Microsoft.AspNetCore.Mvc;
using Sofka.Microservice.Cuentas.ApplicationSettings;

namespace Sofka.Microservice.Cuentas.Controllers;

[Route("api/cuentas")]
[ApiController]
public class CuentaController : BaseApiController<CuentaController>
{
    /// <summary>
    /// Obtiene una lista de todos las cuentas de clientes activos
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> ObtenerClientes()
    {
        var response = new SuccessResponse<ClienteDto[]>();
        response.Data = await Mediator.Send(new ObtenerClientesQuery());

        return Ok(response);
    }
}
