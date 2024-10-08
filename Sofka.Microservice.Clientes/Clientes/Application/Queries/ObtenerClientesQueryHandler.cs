using AutoMapper;
using MediatR;
using Sofka.Microservice.Clientes.Clientes.Application.DTOs;
using Sofka.Microservice.Clientes.Clientes.Domain.Contracts;

namespace Sofka.Microservice.Clientes.Clientes.Application.Queries;

public class ObtenerClientesQuery : IRequest<ClienteDto[]>
{
}

public class ObtenerClientesQueryHandler : IRequestHandler<ObtenerClientesQuery, ClienteDto[]>
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IMapper _mapper;

    public ObtenerClientesQueryHandler(
        IClienteRepository clienteReadRepository,
        IMapper mapper)
    {
        _clienteRepository = clienteReadRepository;
        _mapper = mapper;
    }

    public async Task<ClienteDto[]> Handle(ObtenerClientesQuery request, CancellationToken cancellationToken)
    {
        var clientesEntity = await _clienteRepository.ObtenerClientesAsync();
        var clientesDto = _mapper.Map<ClienteDto[]>(clientesEntity);

        return clientesDto;
    }
}
