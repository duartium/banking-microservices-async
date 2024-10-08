namespace Sofka.Microservice.Cuentas.Database.Context;

public class Movimiento
{
    public int MovimientoId { get; set; }
    public int CuentaId { get; set; }
    public DateTime Fecha { get; set; } 
    public string TipoMovimiento { get; set; } 
    public decimal Valor { get; set; } 
    public decimal Saldo { get; set; } 

    public Cuenta Cuenta { get; set; }
}