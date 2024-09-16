using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pharmaease.Database.Models;

namespace Pharmaease.Database.Mappings
{
    public class MedicamentoMapping : IEntityTypeConfiguration<Medicamento>
    {
        public void Configure(EntityTypeBuilder<Medicamento> builder)
        {
            builder
                .ToTable("T_PE_MEDICAMENTO");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.IdMedicamento)
                .IsRequired();

            builder
                .Property(x => x.NomeMed)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.CodBarra)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.DataCadastro)
                .IsRequired(); // Obrigatório

            builder
                .Property(x => x.DataCancelamento)
                .IsRequired(false); // Opcional

            builder
                .Property(x => x.Fabricante)
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(x => x.CategoriaMed)
                .HasMaxLength(30)
                .IsRequired(false); // Opcional

            builder
                .Property(x => x.Dosagem)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.DataValidade)
                .IsRequired();

            builder
                .Property(x => x.Descricao)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.QuantidadeUni)
                .HasMaxLength(20)
                .IsRequired(false); // Opcional

            builder
                .Property(x => x.DimensaoMed)
                .HasMaxLength(20)
                .IsRequired(false); // Opcional
        }

    }
}
