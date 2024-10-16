using AutoMapper;
using Moq;
using Sofka.Microservice.Cuentas.Database.Context;

namespace Sofka.Architecture.Microservices.UnitTest;

public class CuentaTest
{
    [Fact]
    public async Task Theory_ObtenerCuentas_DeberiaRetornaslistaCuentas()
    {
        var mockMapper = new Mock<IMapper>();
        var mockRepositorioCuentas = new Mock<ICuentaRepository>();
        mockRepositorioCuentas.Setup(repo => repo.ObtenerCuentasAasync())
            .ReturnsAsync(new List<Cuenta>
            {
                new Cuenta { 
                    CuentaId = 1,
                    NumeroCuenta = "000074562",
                    SaldoInicial = 0,
                    TipoCuenta = "AH",
                    Estado = "A",
                },
                new Cuenta {
                    CuentaId = 2,
                    NumeroCuenta = "000098982",
                    SaldoInicial = 0,
                    TipoCuenta = "AH",
                    Estado = "A",
                },
            });

        var handler = new ObtenerCuentasHandler(
            mockMapper.Object, 
            mockRepositorioCuentas.Object);

        var result = await handler.Execute();
        
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
    }
}
