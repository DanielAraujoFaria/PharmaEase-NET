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

        [HttpPatch]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] Medicamento medicamento)
        {
            _medicamentoRepository.Update(medicamento);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] Medicamento medicamento)
        {
            _medicamentoRepository.Delete(medicamento);
            return NoContent();
        }

    }
}
