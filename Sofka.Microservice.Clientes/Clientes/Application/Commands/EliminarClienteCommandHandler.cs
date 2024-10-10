using MediatR;
using Sofka.Microservice.Clientes.Clientes.Domain.Contracts;

namespace Sofka.Microservice.Clientes.Clientes.Application.Commands;

public class EliminarClienteCommand : IRequest
{
    public int IdCliente { get; set; }
}

public class EliminarClienteCommandHandler : IRequestHandler<EliminarClienteCommand>
{
    private readonly IClienteRepository _clienteRepository;

    public EliminarClienteCommandHandler(
        IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task Handle(EliminarClienteCommand requestCrearCliente, CancellationToken cancellationToken)
    {
        await _clienteRepository
            .EliminarClienteAsync(requestCrearCliente.IdCliente);
    }
}
