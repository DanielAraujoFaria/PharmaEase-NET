using Pharmaease.Database.Models;
using Pharmaease.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmaease.Services.Services
{
    public class RecommendationService
    {
        private readonly RecommendationEngine _recommendationEngine;

        public RecommendationService()
        {
            _recommendationEngine = new RecommendationEngine();
        }

        public void TrainModel(IEnumerable<Recomendacao> recomendações)
        {
            _recommendationEngine.TrainModel(recomendações);
        }

        public float Predict(int clienteId, int medicamentoId)
        {
            return _recommendationEngine.Predict(clienteId, medicamentoId);
        }
    }
}
