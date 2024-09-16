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
        // Aplica as configurações de mapeamento específicas para cada entidade
        modelBuilder.ApplyConfiguration(new ClienteMapping());
        modelBuilder.ApplyConfiguration(new MedicamentoMapping());

        // Configurações adicionais se necessário
        // Por exemplo, se tiver mais entidades e configurações

        base.OnModelCreating(modelBuilder);
    }

}
#pragma warning restore CS1591
