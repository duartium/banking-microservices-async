﻿using Microsoft.EntityFrameworkCore;
using Sofka.Microservice.Clientes.Clientes.Application.Commands;
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

    public async Task<int> CrearClienteAsync(CrearClienteCommand clienteCommand)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var nuevaPersona = new Persona
                {
                    Nombre = clienteCommand.Nombres,
                    Direccion = clienteCommand.Direccion,
                    Telefono = clienteCommand.Direccion,
                    Edad = 0,
                    Genero = "",
                    Identificacion = ""
                };

                await _context.Personas.AddAsync(nuevaPersona);
                await _context.SaveChangesAsync();

                var nuevoCliente = new Cliente
                {
                    PersonaId = nuevaPersona.IdPersona,
                    Contrasenia = HashContrasenia(clienteCommand.Contrasenia),
                    Estado = SofkaConstants.ESTADO_ACTIVO,
                };

                await _context.Cliente.AddAsync(nuevoCliente);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return nuevoCliente.IdCliente; 
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public async Task<IEnumerable<Cliente>> ObtenerClientesAsync()
    {
        return await _context.Cliente
            .Include(x => x.Persona)
            .Where(x => x.Estado == SofkaConstants.ESTADO_ACTIVO)
            .AsNoTracking()
            .ToArrayAsync();
    }

    public async Task<bool> ClienteExisteAsync(
        string nombres, 
        string direccion, 
        string telefono)
    {
        return await _context.Personas
                .AnyAsync(u => u.Nombre.Trim().ToUpper() == nombres.Trim().ToUpper() &&
                               u.Direccion.Trim().ToUpper() == direccion.Trim().ToUpper() &&
                               u.Telefono.Trim() == telefono.Trim());
    }

    public async Task EliminarClienteAsync(int idCliente)
    {
        var clienteAEliminar = await _context.Cliente
            .Where(x => x.IdCliente == idCliente)
            .FirstOrDefaultAsync();

        if(clienteAEliminar is null)
            throw new KeyNotFoundException($"El cliente con ID {idCliente} no fue encontrado.");

        clienteAEliminar.Estado = SofkaConstants.ESTADO_INACTIVO;
        _context.Update(clienteAEliminar);
        await _context.SaveChangesAsync();
    }

    private string HashContrasenia(string contrasenia)
    {
        return BCrypt.Net.BCrypt.HashPassword(contrasenia);
    }
}
