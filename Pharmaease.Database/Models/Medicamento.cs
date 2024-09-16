using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmaease.Database.Models
{
    public class Medicamento
    {
        [Column("ID")]
        public int Id { get; set; }
        public int IdMedicamento { get; set; }
        //Torna NomeMed obrigatório
        public required string NomeMed { get; set; }
        public required string CodBarra { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public required string Fabricante { get; set; }
        public required string CategoriaMed { get; set; }
        public required string Dosagem { get; set; }
        public DateTime DataValidade { get; set; } //DataValidade = new DateTime(1990, 5, 21)
        public required string Descricao { get; set; }
        public required string QuantidadeUni { get; set; }
        public required string DimensaoMed { get; set; }

    }
}
