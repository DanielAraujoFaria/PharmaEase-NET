using Microsoft.ML;
using Pharmaease.Database.Models;
using System.Collections.Generic;

namespace Pharmaease.ML
{
    public class RecommendationEngine
    {
        private readonly MLContext _mlContext = new MLContext();
        private ITransformer? _model;

        public void TrainModel(IEnumerable<Recomendacao> clienteRecomList)
        {
            var productRatings = new List<ProductRating>();

            foreach (var recom in clienteRecomList)
            {
                productRatings.Add(new ProductRating
                {
                    ClienteId = recom.IdCliente.ToString(),
                    MedicamentoId = recom.IdMedicamento.ToString(),
                    Label = 1
                });
            }

            // Dados
            var trainingData = _mlContext.Data.LoadFromEnumerable(productRatings);

            // Pipeline
            var pipeline = _mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "clienteIdEncoded", inputColumnName: nameof(ProductRating.ClienteId))
                .Append(_mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "medicamentoIdEncoded", inputColumnName: nameof(ProductRating.MedicamentoId)))
                .Append(_mlContext.Recommendation().Trainers.MatrixFactorization(
                    labelColumnName: nameof(ProductRating.Label),
                    matrixColumnIndexColumnName: "clienteIdEncoded",
                    matrixRowIndexColumnName: "medicamentoIdEncoded"));

            _model = pipeline.Fit(trainingData);
        }

        public float Predict(int clienteId, int medicamentoId)
        {
            var predictionEngine = _mlContext.Model.CreatePredictionEngine<ProductRating, ProductPrediction>(_model);

            var prediction = predictionEngine.Predict(new ProductRating
            {
                ClienteId = clienteId.ToString(),
                MedicamentoId = medicamentoId.ToString()
            });

            return prediction.Score;
        }

        public class ProductPrediction
        {
            public float Score { get; set; }
        }

        public class ProductRating
        {
            public string? ClienteId { get; set; }
            public string? MedicamentoId { get; set; }
            public float Label { get; set; }
        }
    }
}
