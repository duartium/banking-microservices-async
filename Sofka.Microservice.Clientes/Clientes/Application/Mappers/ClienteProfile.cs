using AutoMapper;
using Sofka.Microservice.Clientes.Clientes.Application.Commands;
using Sofka.Microservice.Clientes.Clientes.Application.DTOs;
using Sofka.Microservice.Clientes.Clientes.Domain.Models;
using Sofka.Microservice.Clientes.database.Context;

namespace Sofka.Microservice.Clientes.Clientes.Application.Mappers;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<Cliente, ClienteDto>()
            .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Persona.Nombre))
            .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Persona.Genero))
            .ForMember(dest => dest.Edad, opt => opt.MapFrom(src => src.Persona.Edad))
            .ForMember(dest => dest.Identificacion, opt => opt.MapFrom(src => src.Persona.Identificacion))
            .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.Persona.Direccion))
            .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.Persona.Telefono))
            .ReverseMap()
            .ForPath(src => src.Persona.Nombre, opt => opt.MapFrom(dest => dest.Nombre))
            .ForPath(src => src.Persona.Genero, opt => opt.MapFrom(dest => dest.Genero))
            .ForPath(src => src.Persona.Edad, opt => opt.MapFrom(dest => dest.Edad))
            .ForPath(src => src.Persona.Identificacion, opt => opt.MapFrom(dest => dest.Identificacion))
            .ForPath(src => src.Persona.Direccion, opt => opt.MapFrom(dest => dest.Direccion))
            .ForPath(src => src.Persona.Telefono, opt => opt.MapFrom(dest => dest.Telefono));

        CreateMap<CrearClienteCommand, Cliente>().ReverseMap();

    }
}

#region Mapeos manuales personaliados para clientes
public static class MapClientes
{
    public static ClienteCompleto ToClienteCompleto(Cliente clienteEntity)
    {
        if(clienteEntity is null || clienteEntity.Persona is null)
            throw new ArgumentNullException(nameof(clienteEntity));

        return new ClienteCompleto
        {
            Identificacion = clienteEntity.Persona.Identificacion,
            Nombres = clienteEntity.Persona.Nombre,
            Direccion = clienteEntity.Persona.Direccion,
            Edad = clienteEntity.Persona.Edad,
            Genero = clienteEntity.Persona.Genero,
            Telefono = clienteEntity.Persona.Telefono,
            Estado = clienteEntity.Estado,
            IdCliente = clienteEntity.IdCliente,
            IdPersona = clienteEntity.PersonaId
        };
    }
}
#endregion