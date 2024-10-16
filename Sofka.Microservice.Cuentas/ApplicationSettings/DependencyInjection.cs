namespace Sofka.Microservice.Cuentas.ApplicationSettings;

public static class DependencyInjection
{
    public static IServiceCollection AddCuentasMicroserviceDependencies(this IServiceCollection services)
    {
        //services.AddScoped<IClienteRepository, ClienteRepository>();

        return services;
    }
}

