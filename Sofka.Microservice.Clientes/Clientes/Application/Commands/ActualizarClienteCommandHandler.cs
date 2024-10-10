using MediatR;
using Sofka.Microservice.Clientes.Clientes.Domain.Contracts;
using Sofka.Microservice.Clientes.Clientes.Domain.Models;

namespace Sofka.Microservice.Clientes.Clientes.Application.Commands;

public class ActualizarClienteCommand : ClientePersona, IRequest<ClienteCompleto>
{
    public string Identificacion { get; set; } = "";
    public string Genero { get; set; } = "";
    public int Edad { get; set; }
}

public class ActualizarClienteCommandHandler : IRequestHandler<ActualizarClienteCommand, ClienteCompleto>
{

    private readonly IClienteRepository _clienteRepository;

    public ActualizarClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ClienteCompleto> Handle(ActualizarClienteCommand actualizarClienteCommand, CancellationToken cancellationToken)
    => await _clienteRepository.ActualizarClienteCommandAsync(actualizarClienteCommand);
}
