using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sofka.Microservice.Cuentas.ApplicationSettings;

namespace Sofka.Microservice.Cuentas.Controllers;

[Route("api/movimiento-cuentas/")]
[ApiController]
public class MovimientoCuentaController : BaseApiController<MovimientoCuentaController>
{
    /// <summary>
    /// Obtiene los movimientos las cuentas de clientes activos
    /// </summary>
    /// <returns></returns>
    //[HttpGet]
    //public async Task<IActionResult> ObtenerClientes()
    //{
    //    var response = new SuccessResponse<ClienteDto[]>();
    //    response.Data = await Mediator.Send(new ObtenerClientesQuery());

    //    return Ok(response);
    //}
}
