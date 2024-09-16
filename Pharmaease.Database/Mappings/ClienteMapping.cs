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
                .IsRequired();

            builder
                .Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.CPF)
                .HasMaxLength(15)
                .IsRequired();

            builder
                .Property(x => x.DataCadastro)
                .IsRequired(); // Obrigatório

            builder
                .Property(x => x.DataCancelamento)
                .IsRequired(false); // Opcional
        }
    }
}
