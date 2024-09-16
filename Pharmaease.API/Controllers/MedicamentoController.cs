using Microsoft.AspNetCore.Mvc;
using Pharmaease.Database.Models;
using Pharmaease.Repository.Interface;
using System.Net;

namespace Pharmaease.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {
        private readonly IRepository<Medicamento> _medicamentoRepository;

        public MedicamentoController(IRepository<Medicamento> medicamentoRepository)
        {
            _medicamentoRepository = medicamentoRepository;
        }

        /// <summary>
        /// Cadastra um novo medicamento.
        /// </summary>
        /// <param name="medicamento">Objeto medicamento a ser criado.</param>
        /// <returns>O medicamento recém-criado.</returns>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /Medicamento
        ///     {
        ///         "id": 1,
        ///         "nome": "Paracetamol",
        ///         "dose": "500mg",
        ///         "laboratorio": "Laboratório XYZ",
        ///         "dataCadastro": "2024-09-16T20:56:02.143Z"
        ///     }
        /// </remarks>
        /// <response code="201">Medicamento criado com sucesso.</response>
        /// <response code="400">O medicamento fornecido é inválido.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost]
        [ProducesResponseType(typeof(Medicamento), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Medicamento medicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _medicamentoRepository.Add(medicamento);
                var createdMedicamento = _medicamentoRepository.GetById(medicamento.Id);
                return CreatedAtAction(nameof(GetById), new { id = createdMedicamento.Id }, createdMedicamento);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Retorna todos os medicamentos cadastrados.
        /// </summary>
        /// <returns>Lista de medicamentos.</returns>
        /// <response code="200">Lista de medicamentos retornada com sucesso.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Medicamento>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            try
            {
                var medicamentos = _medicamentoRepository.GetAll();
                return Ok(medicamentos);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Retorna um medicamento específico pelo ID.
        /// </summary>
        /// <param name="id">ID do medicamento.</param>
        /// <returns>Objeto medicamento.</returns>
        /// <response code="200">Medicamento encontrado.</response>
        /// <response code="404">Medicamento não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Medicamento), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetById(int id)
        {
            try
            {
                var medicamento = _medicamentoRepository.GetById(id);
                if (medicamento == null)
                {
                    return NotFound();
                }
                return Ok(medicamento);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Atualiza um medicamento existente.
        /// </summary>
        /// <param name="id">ID do medicamento a ser atualizado.</param>
        /// <param name="medicamento">Dados atualizados do medicamento.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="200">Medicamento atualizado com sucesso.</response>
        /// <response code="404">Medicamento não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Put(int id, [FromBody] Medicamento medicamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingMedicamento = _medicamentoRepository.GetById(id);
                if (existingMedicamento == null)
                {
                    return NotFound();
                }

                medicamento.Id = id; // Garantindo que o ID seja consistente
                _medicamentoRepository.Update(medicamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Exclui um medicamento pelo ID.
        /// </summary>
        /// <param name="id">ID do medicamento a ser excluído.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="204">Medicamento excluído com sucesso.</response>
        /// <response code="404">Medicamento não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete(int id)
        {
            try
            {
                var medicamento = _medicamentoRepository.GetById(id);
                if (medicamento == null)
                {
                    return NotFound();
                }

                _medicamentoRepository.Delete(medicamento);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
