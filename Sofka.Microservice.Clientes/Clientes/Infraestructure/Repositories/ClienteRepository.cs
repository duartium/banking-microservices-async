using Microsoft.EntityFrameworkCore;
using Sofka.Architecture.Microservices.Common;
using Sofka.Microservice.Clientes.Clientes.Domain.Contracts;
using Sofka.Microservice.Clientes.database.Context;

namespace Sofka.Microservice.Clientes.Clientes.Infraestructure.Repositories;

public class ClienteRepository : IClienteRepository
{
    private readonly AppDbContext _context;

    public ClienteRepository(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public Task AgregarClienteAsync(Cliente nuevoCliente)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Cliente>> ObtenerClientesAsync()
    {
        return await _context.Cliente
            .Where(x => x.Estado == SofkaConstants.ESTADO_ACTIVO)
            .AsNoTracking()
            .ToArrayAsync();
    }
}
