using Microsoft.AspNetCore.Mvc;

namespace Sofka.Microservice.Clientes.Personas.Application;

[Route("api/personas")]
[ApiController]
public class PersonaController : BaseApiController<PersonaController>
{
}
