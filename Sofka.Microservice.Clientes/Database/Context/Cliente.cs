namespace Sofka.Microservice.Clientes.database.Context;

public class Cliente
{
    public int IdCliente { get; set; }
    public int PersonaId { get; set; }
    public string Contrasenia { get; set; }
    public string Estado { get; set; }
    public Persona Persona { get; set; }
}
