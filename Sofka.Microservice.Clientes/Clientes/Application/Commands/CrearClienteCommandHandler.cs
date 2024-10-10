using MediatR;
using Sofka.Microservice.Clientes.Clientes.Domain.Contracts;
using Sofka.Microservice.Clientes.Clientes.Domain.Models;

namespace Sofka.Microservice.Clientes.Clientes.Application.Commands;

public class CrearClienteCommand : ClientePersona, IRequest<int>
{
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