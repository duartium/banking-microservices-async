namespace Sofka.Microservice.Clientes.Clientes.Domain.Models;

/// <summary>
/// Composicion de propiedades de las clases de cliente y persona 
/// que indica al usuario los datos actualizados del cliente
/// </summary>
public class ClienteCompleto
{
    public int IdCliente { get; set; }
    public int IdPersona { get; set; }
    public string Nombres { get; set; } = "";
    public string Direccion { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string Identificacion { get; set; } = "";
    public string Genero { get; set; } = "";
    public int Edad { get; set; }
    public string Estado { get; set; } = "";
}