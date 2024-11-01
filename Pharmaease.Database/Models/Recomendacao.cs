using System;

namespace Pharmaease.Database.Models
{
    public class Recomendacao
    {
        public int Id { get; set; }
        public int IdMedicamento { get; set; }
        public int IdCliente { get; set; }
        public required string Sintoma { get; set; }
        public DateTime DataRecomendacao { get; set; }
        public string? HistoricoCompras { get; set; }

        public bool IsRecent()
        {
            return (DateTime.Now - DataRecomendacao).TotalDays < 30; // 30 dias
        }
    }
}
