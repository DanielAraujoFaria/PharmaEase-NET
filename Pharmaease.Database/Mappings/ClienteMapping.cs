using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmaease.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmaease.Database.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder
                .ToTable("T_PE_CLIENTE");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.IdCliente)
                .HasColumnName("IDCLIENTE")
                .IsRequired();

            builder
                .Property(x => x.Nome)
                .HasMaxLength(50)
                .HasColumnName("NOME")
                .IsRequired();

            builder
                .Property(x => x.CPF)
                .HasMaxLength(15)
                .HasColumnName("CPF")
                .IsRequired();

            builder
                .Property(x => x.DataCadastro)
                .HasColumnName("DATACADASTRO")
                .IsRequired(); // Obrigatório

            builder
                .Property(x => x.DataCancelamento)
                .HasColumnName("DATACANCELAMENTO")
                .IsRequired(false); // Opcional
        }
    }
}
