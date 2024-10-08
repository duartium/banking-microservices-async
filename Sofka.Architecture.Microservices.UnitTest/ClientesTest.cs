using AutoMapper;
using Moq;
using Sofka.Microservice.Clientes.Clientes.Application.Commands;
using Sofka.Microservice.Clientes.Clientes.Application.DTOs;
using Sofka.Microservice.Clientes.Clientes.Application.Queries;
using Sofka.Microservice.Clientes.Clientes.Domain.Contracts;
using Sofka.Microservice.Clientes.database.Context;
namespace Sofka.Architecture.Microservices.UnitTest;

public class ClientesTest
{
    [Fact]
    public async Task ObtenerClientes_DeberiaRetornarListaDeClientes()
    {
        var mockClienteRepository = new Mock<IClienteRepository>();

        var listaClientes = new List<Cliente>
        {
            new Cliente { IdCliente = 1, Estado = "Activo", Persona = new Persona { Nombre = "Byron Duarte" } },
            new Cliente { IdCliente = 2, Estado = "Inactivo", Persona = new Persona { Nombre = "Ana Lopez" } }
        };

        mockClienteRepository.Setup(repo => repo.ObtenerClientesAsync())
                             .ReturnsAsync(listaClientes);

        var mockMapper = new Mock<IMapper>();
        mockMapper.Setup(m => m.Map<ClienteDto[]>(It.IsAny<List<Cliente>>()))
                  .Returns((List<Cliente> clientes) =>
                  {
                      return clientes.Select(c => new ClienteDto
                      {
                          IdCliente = c.IdCliente,
                          Nombre = c.Persona.Nombre,
                      }).ToArray();
                  });

        var handler = new ObtenerClientesQueryHandler(mockClienteRepository.Object, mockMapper.Object);

        var query = new ObtenerClientesQuery();
        var cancellationToken = new CancellationToken();
        var result = await handler.Handle(query, cancellationToken);

        Assert.NotNull(result);
        Assert.Equal(2, result.Length);
        Assert.Equal("Byron Duarte", result[0].Nombre);
    }

    [Fact]
    public async Task CrearClienteAsync_DeberiaGuardarCliente()
    {
        var mockClienteRepository = new Mock<IClienteRepository>();

        var command = new CrearClienteCommand
        {
            Nombres = "Byron Duarte",
            Direccion = "Calle Falsa 123",
            Telefono = "0991234567",
            Contrasenia = "password123",
        };

        var handler = new CrearClienteCommandHandler(mockClienteRepository.Object);

        await handler.Handle(command, CancellationToken.None);

        mockClienteRepository.Verify(repo => repo.CrearClienteAsync(It.Is<CrearClienteCommand>(c =>
            c.Nombres == command.Nombres &&
            c.Direccion == command.Direccion &&
            c.Telefono == command.Telefono &&
            c.Contrasenia == command.Contrasenia
        )), Times.Once);
    }
}