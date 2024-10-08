using MediatR;
using Sofka.Microservice.Clientes.Clientes.Domain.Contracts;

namespace Sofka.Microservice.Clientes.Clientes.Application.Commands;

public class CrearClienteCommand : IRequest<int>
{
    public string Nombres { get; set; } = "";
    public string Direccion { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Contrasenia { get; set; } = "";
}

public class CrearClienteCommandHandler : IRequestHandler<CrearClienteCommand, int>
{
    private readonly IClienteRepository _clienteRepository;

    public CrearClienteCommandHandler(
        IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<int> Handle(CrearClienteCommand requestCrearCliente, CancellationToken cancellationToken)
    {
        bool esClienteExistente = await _clienteRepository.ClienteExisteAsync(
            requestCrearCliente.Nombres,
            requestCrearCliente.Direccion,
            requestCrearCliente.Telefono);

        if (esClienteExistente) throw new ApplicationException("El cliente que intenta crear ya existe");

        return await _clienteRepository
            .CrearClienteAsync(requestCrearCliente);
    }
}