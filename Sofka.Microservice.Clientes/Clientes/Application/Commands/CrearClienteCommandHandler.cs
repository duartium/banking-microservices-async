using Sofka.Microservice.Clientes.Clientes.Domain.Contracts;
using Sofka.Microservice.Clientes.database.Context;

namespace Sofka.Microservice.Clientes.Clientes.Application.Commands;

public class CrearClienteCommand
{
    public string Nombre { get; set; }
    public string Identificacion { get; set; }
}

public class CrearClienteCommandHandler
{
    private readonly IClienteRepository _clienteRepository;

    public CrearClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task HandleAsync(CrearClienteCommand command)
    {
        //var cliente = new Cliente(command.Nombre, command.Identificacion);

        await _clienteRepository.AgregarClienteAsync(new Cliente());
    }
}