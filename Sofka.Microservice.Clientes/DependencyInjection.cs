using Sofka.Microservice.Clientes.Clientes.Domain.Contracts;
using Sofka.Microservice.Clientes.Clientes.Infraestructure.Repositories;

namespace Sofka.Microservice.Clientes.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddClientesMicroserviceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IClienteRepository, ClienteRepository>();

        return services;
    }
}

