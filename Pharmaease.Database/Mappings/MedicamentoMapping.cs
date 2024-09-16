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
                .HasColumnName("IDMEDICAMENTO")
                .IsRequired();

            builder
                .Property(x => x.NomeMed)
                .HasColumnName("NOMEMED")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.CodBarra)
                .HasColumnName("CODBARRA")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.DataCadastro)
                .HasColumnName("DATACADASTRO")
                .IsRequired(); // Obrigatório

            builder
                .Property(x => x.DataCancelamento)
                .HasColumnName("DATACANCELAMENTO")
                .IsRequired(false); // Opcional

            builder
                .Property(x => x.Fabricante)
                .HasColumnName("FABRICANTE")
                .HasMaxLength(30)
                .IsRequired();

            builder
                .Property(x => x.CategoriaMed)
                .HasColumnName("CATEGORIAMED")
                .HasMaxLength(30)
                .IsRequired(false); // Opcional

            builder
                .Property(x => x.Dosagem)
                .HasColumnName("DOSAGEM")
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.DataValidade)
                .HasColumnName("DATAVALIDADE")
                .IsRequired();

            builder
                .Property(x => x.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.QuantidadeUni)
                .HasColumnName("QUANTIDADEUNI")
                .HasMaxLength(20)
                .IsRequired(false); // Opcional

            builder
                .Property(x => x.DimensaoMed)
                .HasColumnName("DIMENSAOMED")
                .HasMaxLength(20)
                .IsRequired(false); // Opcional
        }
    }
}
