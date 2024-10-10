namespace Sofka.Microservice.Clientes.Clientes.Domain.Models;

/// <summary>
/// Contiene las propiedades comunes entre el command de creación y eliminación de un cliente - persona
/// </summary>
public class ClientePersona {
    public string Nombres { get; set; } = "";
    public string Direccion { get; set; } = "";
    public string Telefono { get; set; } = "";
}
