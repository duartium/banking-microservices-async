using Sofka.Microservice.Clientes.database.Context;

namespace Sofka.Microservice.Clientes.Clientes.Domain.Contracts;

public interface IClienteRepository
{
    Task<IEnumerable<Cliente>> ObtenerClientesAsync();
    Task AgregarClienteAsync(Cliente nuevoCliente);
}
