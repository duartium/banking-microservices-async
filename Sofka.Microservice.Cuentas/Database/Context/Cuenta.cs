namespace Sofka.Microservice.Cuentas.Database.Context;

public class Cuenta
{
    public int CuentaId { get; set; } 
    public string NumeroCuenta { get; set; }
    public string TipoCuenta { get; set; } 
    public decimal SaldoInicial { get; set; } 
    public string Estado { get; set; }
    public ICollection<Movimiento> Movimientos { get; set; }

}
