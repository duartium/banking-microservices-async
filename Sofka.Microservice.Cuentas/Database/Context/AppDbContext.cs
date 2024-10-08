using Microsoft.EntityFrameworkCore;

namespace Sofka.Microservice.Cuentas.Database.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Cuenta> Cuentas { get; set; }
    public DbSet<Movimiento> Movimientos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cuenta>()
           .HasKey(c => c.CuentaId);

        modelBuilder.Entity<Cuenta>()
            .Property(c => c.CuentaId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Cuenta>()
            .HasIndex(c => c.NumeroCuenta)
            .IsUnique();

        modelBuilder.Entity<Movimiento>()
           .HasKey(m => m.MovimientoId);

        modelBuilder.Entity<Movimiento>()
            .Property(m => m.MovimientoId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Movimiento>()
            .HasIndex(m => m.MovimientoId)
            .IsUnique();

        modelBuilder.Entity<Movimiento>()
            .HasOne(m => m.Cuenta)
            .WithMany(c => c.Movimientos)
            .HasForeignKey(m => m.CuentaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
