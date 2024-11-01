using Xunit;
using Pharmaease.Services;
using Pharmaease.Database.Models;
using System.Collections.Generic;
using Pharmaease.Services.Services;

namespace Pharmaease.Tests
{
    public class RecommendationServiceTests
    {
        [Fact]
        public void TestTrainAndPredict()
        {
            var recommendationService = new RecommendationService();

            var listaRecomendacoes = new List<Recomendacao>
            {
                new Recomendacao { IdCliente = 1, IdMedicamento = 101, Sintoma = "Dor de cabeça", DataRecomendacao = DateTime.Now },
            };

            recommendationService.TrainModel(listaRecomendacoes);

            float score = recommendationService.Predict(clienteId: 1, medicamentoId: 101);
            Assert.True(score >= 0);
        }
    }
}
