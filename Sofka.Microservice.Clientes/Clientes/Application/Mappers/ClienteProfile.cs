using AutoMapper;
using Sofka.Microservice.Clientes.Clientes.Application.Commands;
using Sofka.Microservice.Clientes.Clientes.Application.DTOs;
using Sofka.Microservice.Clientes.database.Context;

namespace Sofka.Microservice.Clientes.Clientes.Application.Mappers;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<Cliente, ClienteDto>().ReverseMap();
        CreateMap<CrearClienteCommand, Cliente>().ReverseMap();

    }
}
