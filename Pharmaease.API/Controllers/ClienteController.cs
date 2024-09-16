using Microsoft.AspNetCore.Mvc;
using Pharmaease.Database.Models;
using Pharmaease.Repository.Interface;
using System.Net;

namespace Pharmaease.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IRepository<Cliente> _clienteRepository;

        public ClienteController(IRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            _clienteRepository.Add(cliente);
            return Created();
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Cliente>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var cliente = _clienteRepository.GetAll();
            return Ok(cliente);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPatch]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Patch([FromBody] Cliente cliente)
        {
            _clienteRepository.Update(cliente);
            return Ok();
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete([FromBody] Cliente cliente)
        {
            _clienteRepository.Delete(cliente);
            return NoContent();
        }
    }
}
