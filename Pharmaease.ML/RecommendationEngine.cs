using Microsoft.ML;
using Pharmaease.Database.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Pharmaease.ML
{
    public class RecommendationEngine
    {
        private readonly MLContext _mlContext;
        private ITransformer? _model;

        public RecommendationEngine()
        {
            _mlContext = new MLContext();
        }

        public void TrainModel(IEnumerable<Recomendacao> clienteRecomList)
        {
            var productRatings = clienteRecomList.Select(recom => new ProductRating
            {
                ClienteId = recom.IdCliente.ToString(),
                MedicamentoId = recom.IdMedicamento.ToString(),
                Label = CalculateScore(recom)
            }).ToList();

            var trainingData = _mlContext.Data.LoadFromEnumerable(productRatings);

            var pipeline = _mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "clienteIdEncoded", inputColumnName: nameof(ProductRating.ClienteId))
                .Append(_mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "medicamentoIdEncoded", inputColumnName: nameof(ProductRating.MedicamentoId)))
                .Append(_mlContext.Recommendation().Trainers.MatrixFactorization(
                    labelColumnName: nameof(ProductRating.Label),
                    matrixColumnIndexColumnName: "clienteIdEncoded",
                    matrixRowIndexColumnName: "medicamentoIdEncoded"));

            _model = pipeline.Fit(trainingData);
        }

        private float CalculateScore(Recomendacao recomendacao)
        {
            switch (recomendacao.Sintoma)
            {
                case "Dor de cabeça":
                    return 1.0f;
                case "Febre":
                    return 0.5f;
                case "Dor muscular":
                    return 0.8f;
                case "Congestão nasal":
                    return 0.6f;
                case "Tosse":
                    return 0.7f;
                case "Náusea":
                    return 0.4f;
                case "Alergia":
                    return 0.9f;
                case "Cansaço":
                    return 0.3f;
                default:
                    return -1.0f;
            }
        }

        public float Predict(int clienteId, int medicamentoId)
        {
            if (_model == null)
                throw new InvalidOperationException("O modelo não foi treinado.");

            var predictionEngine = _mlContext.Model.CreatePredictionEngine<ProductRating, ProductPrediction>(_model);

            var prediction = predictionEngine.Predict(new ProductRating
            {
                ClienteId = clienteId.ToString(),
                MedicamentoId = medicamentoId.ToString()
            });

            return NormalizeScore(prediction.Score);
        }

        private float NormalizeScore(float score)
        {
            return (score > 0) ? 1.0f : (score < 0) ? -1.0f : 0.0f;
        }

        public List<(int medicamentoId, float score)> Recommend(int clienteId, IEnumerable<Medicamento> todosMedicamentos, int topN = 5)
        {
            var recommendations = new List<(int medicamentoId, float score)>();

            foreach (var medicamento in todosMedicamentos)
            {
                var score = Predict(clienteId, medicamento.IdMedicamento);
                recommendations.Add((medicamento.IdMedicamento, score));
            }

            return recommendations.OrderByDescending(x => x.score).Take(topN).ToList();
        }

        public void SaveModel(string path)
        {
            if (_model == null)
                throw new InvalidOperationException("O modelo não foi treinado.");

            _mlContext.Model.Save(_model, _mlContext.Data.LoadFromEnumerable(new List<ProductRating>()).Schema, path);
        }

        public void LoadModel(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"O modelo não foi encontrado em {path}.");

            _model = _mlContext.Model.Load(path, out var modelInputSchema);
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
