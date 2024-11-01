using Microsoft.EntityFrameworkCore;
using Pharmaease.Database.Mappings;
using Pharmaease.Database.Models;

#pragma warning disable CS1591
public class PharmaDBContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }

    public PharmaDBContext(DbContextOptions<PharmaDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteMapping());
        modelBuilder.ApplyConfiguration(new MedicamentoMapping());

        base.OnModelCreating(modelBuilder);
    }

}
#pragma warning restore CS1591
