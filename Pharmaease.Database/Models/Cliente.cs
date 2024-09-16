using Pharmaease.Repository.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmaease.Database.Models
{

    public class Cliente : IEntity
    {
        [Column("ID")]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public required string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataCancelamento { get; set; }
    }
}
