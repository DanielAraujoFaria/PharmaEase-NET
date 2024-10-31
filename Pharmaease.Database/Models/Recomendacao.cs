using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
