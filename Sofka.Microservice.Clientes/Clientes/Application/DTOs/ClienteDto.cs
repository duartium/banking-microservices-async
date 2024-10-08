using System.Text.Json.Serialization;

namespace Sofka.Microservice.Clientes.Clientes.Application.DTOs;

public class ClienteDto
{
    [JsonPropertyName("id")]
    public int IdCliente { get; set; }
    public int PersonaId { get; set; }
    [JsonPropertyName("nombres")]
    public string Nombre { get; set; } = "";
    public string Genero { get; set; } = "";
    public int Edad { get; set; }
    public string Identificacion { get; set; } = "";
    public string Direccion { get; set; } = "";
    public string Telefono { get; set; } = "";
}