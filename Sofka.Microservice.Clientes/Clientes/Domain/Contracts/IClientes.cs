using Sofka.Microservice.Clientes.Clientes.Application.Commands;
using Sofka.Microservice.Clientes.database.Context;

namespace Sofka.Microservice.Clientes.Clientes.Domain.Contracts;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> ObtenerClientesAsync();
    Task<int> CrearClienteAsync(CrearClienteCommand nuevoCliente);
    Task<bool> ClienteExisteAsync(
        string nombres,
        string direccion,
        string telefono);
    Task EliminarClienteAsync(int idCliente);
}
