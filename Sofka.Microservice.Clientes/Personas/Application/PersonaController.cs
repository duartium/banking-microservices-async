using Microsoft.AspNetCore.Mvc;
using Sofka.Microservice.Clientes.ApplicationSettings;

namespace Sofka.Microservice.Clientes.Personas.Application;

[Route("api/personas")]
[ApiController]
public class PersonaController : BaseApiController<PersonaController>
{
}
