using Microsoft.AspNetCore.Mvc;
using Pharmaease.Database.Models;
using Pharmaease.Services.Services;

namespace Pharmaease.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly RecommendationService _recommendationService;

        public RecommendationController()
        {
            _recommendationService = new RecommendationService();
        }

        [HttpPost("train")]
        public IActionResult TrainModel([FromBody] List<Recomendacao> recomendacoes)
        {
            _recommendationService.TrainModel(recomendacoes);
            return Ok("Modelo treinado com sucesso.");
        }

        [HttpGet("predict")]
        public IActionResult Predict(int clienteId, int medicamentoId)
        {
            float score = _recommendationService.Predict(clienteId, medicamentoId);
            return Ok(new { Score = score });
        }
    }
}
