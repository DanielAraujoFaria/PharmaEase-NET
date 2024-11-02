using Pharmaease.Services.OpenFDA;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Pharmaease.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FDAController : ControllerBase
    {
        private readonly IMediServices _mediServices;

        public FDAController(IMediServices mediServices)
        {
            _mediServices = mediServices;
        }

        /// <summary>
        /// Obtém informações sobre um medicamento com base no nome da marca.
        /// </summary>
        /// <param name="brandName">O nome da marca do medicamento a ser buscado.</param>
        /// <returns>As informações do medicamento encontrado.</returns>
        /// <remarks>
        /// A API OpenFDA é uma Api em ingês sobre consulta de medicamentos, abaixo deixamos algumas sugestões 
        /// de medicamentos! Boa Pesquisa!
        /// 
        /// Medicamentos sugeridos:
        ///    - ACETAMINOPHEN
        ///    - SILICEA
        ///    - ADVIL
        ///    - ZYRTEC
        ///    - IBUPROFEN
        ///    - NAPROXEN
        ///     
        /// Note que alguns medicamentos podem ter algumas informações faltando. Isso NÃO é um erro da aplicação 
        /// mas na verdade da Api que pode não ter todas as informações documentadas sobre dito medicamento!
        /// </remarks>
        /// <response code="200">Medicamento encontrado com sucesso.</response>
        /// <response code="400">O nome da marca fornecido é inválido.</response>
        /// <response code="404">Medicamento não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(MediResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetMediByBrandName(string brandName)
        {
            if (string.IsNullOrWhiteSpace(brandName))
            {
                return BadRequest("Nome da marca não pode ser nulo ou vazio");
            }

            var response = await _mediServices.GetMediByBrandName(brandName);

            if (response == null)
            {
                return NotFound("Medicamento não encontrado.");
            }

            return Ok(response);
        }
    }
}
