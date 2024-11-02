using Pharmaease.Database.Models;
using Pharmaease.ML;
using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var interacoes = new List<Recomendacao>
        {
            new Recomendacao { Id = 1, IdCliente = 1, IdMedicamento = 101, Sintoma = "Dor de cabeça", DataRecomendacao = DateTime.Now },
            new Recomendacao { Id = 2, IdCliente = 1, IdMedicamento = 102, Sintoma = "Febre", DataRecomendacao = DateTime.Now },
            new Recomendacao { Id = 3, IdCliente = 2, IdMedicamento = 101, Sintoma = "Dor de cabeça", DataRecomendacao = DateTime.Now },
            new Recomendacao { Id = 4, IdCliente = 3, IdMedicamento = 103, Sintoma = "Dor muscular", DataRecomendacao = DateTime.Now },
            new Recomendacao { Id = 5, IdCliente = 4, IdMedicamento = 104, Sintoma = "Congestão nasal", DataRecomendacao = DateTime.Now },
            new Recomendacao { Id = 6, IdCliente = 2, IdMedicamento = 105, Sintoma = "Tosse", DataRecomendacao = DateTime.Now },
            new Recomendacao { Id = 7, IdCliente = 5, IdMedicamento = 106, Sintoma = "Náusea", DataRecomendacao = DateTime.Now },
            new Recomendacao { Id = 8, IdCliente = 3, IdMedicamento = 107, Sintoma = "Alergia", DataRecomendacao = DateTime.Now },
            new Recomendacao { Id = 9, IdCliente = 4, IdMedicamento = 108, Sintoma = "Cansaço", DataRecomendacao = DateTime.Now },
            new Recomendacao { Id = 10, IdCliente = 5, IdMedicamento = 109, Sintoma = "Febre", DataRecomendacao = DateTime.Now },
        };

        var engine = new RecommendationEngine();
        engine.TrainModel(interacoes);

        int clienteId = 1;
        int medicamentoId = 101;
        float score = engine.Predict(clienteId, medicamentoId);

        Console.WriteLine($"Score de recomendação para Cliente {clienteId} e Medicamento {medicamentoId}: {score}");
    }
}
