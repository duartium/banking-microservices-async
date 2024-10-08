namespace Sofka.Microservice.Clientes.database.Context;

public class Cliente
{
    public int IdCliente { get; set; }
    public int PersonaId { get; set; }
    public string Nombre { get; set; }
    public string Genero { get; set; }
    public int Edad { get; set; }
    public string Identificacion { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Contraseña { get; set; }
    public string Estado { get; set; }
    public Persona Persona { get; set; }
}
