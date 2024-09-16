using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmaease.Database.Models
{
    public class Cliente
    {
        [Column("ID")]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        //Torna Nome obrigatório
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataCancelamento { get; set; } //DataCancelamento = new DateTime(1990, 5, 21)

    }
}