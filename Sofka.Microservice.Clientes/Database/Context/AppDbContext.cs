using Microsoft.EntityFrameworkCore;

namespace Sofka.Microservice.Clientes.database.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<Persona> Personas { get; set; }
    public DbSet<Cliente> Cliente { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Persona>()
           .HasKey(p => p.IdPersona);

        modelBuilder.Entity<Persona>()
            .Property(p => p.IdPersona)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Cliente>()
            .HasKey(c => c.IdCliente);

        modelBuilder.Entity<Cliente>()
            .Property(c => c.IdCliente)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Cliente>()
            .HasIndex(c => c.IdCliente)
            .IsUnique();

        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Persona)
            .WithMany()
            .HasForeignKey(c => c.PersonaId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
