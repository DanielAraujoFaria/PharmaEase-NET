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

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Medicamento medicamento)
        {
            _medicamentoRepository.Add(medicamento);
            return Created();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Medicamento>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var medicamento = _medicamentoRepository.GetAll();
            return Ok(medicamento);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Medicamento), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetById(int id)
        {
            var medicamento = _medicamentoRepository.GetById(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            return Ok(medicamento);
        }

        // Changed Patch to Put
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Put(int id, [FromBody] Medicamento medicamento)
        {
            var existingMedicamento = _medicamentoRepository.GetById(id);
            if (existingMedicamento == null)
            {
                return NotFound();
            }

            medicamento.Id = id; // Ensuring the ID is consistent
            _medicamentoRepository.Update(medicamento);
            return Ok();
        }

        // Changed Delete to take id as a parameter
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete(int id)
        {
            var medicamento = _medicamentoRepository.GetById(id);
            if (medicamento == null)
            {
                return NotFound();
            }

            _medicamentoRepository.Delete(medicamento);
            return NoContent();
        }
    }
}
