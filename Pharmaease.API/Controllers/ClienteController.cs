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

        /// <summary>
        /// Cadastra um novo cliente.
        /// </summary>
        /// <param name="cliente">Objeto cliente a ser criado.</param>
        /// <returns>O cliente recém-criado.</returns>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST /Cliente
        ///     {
        ///         "idCliente": 1,
        ///         "nome": "João Silva",
        ///         "cpf": "123.456.789-00",
        ///         "dataCadastro": "2023-09-01"
        ///     }
        /// </remarks>
        /// <response code="201">Cliente criado com sucesso.</response>
        /// <response code="400">O cliente fornecido é inválido.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            _clienteRepository.Add(cliente);
            return Created();
        }

        /// <summary>
        /// Retorna todos os clientes cadastrados.
        /// </summary>
        /// <returns>Lista de clientes.</returns>
        /// <response code="200">Lista de clientes retornada com sucesso.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Cliente>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [HttpGet]
        [ProducesResponseType(typeof(List<Cliente>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetAll()
        {
            var cliente = _clienteRepository.GetAll();
            return Ok(cliente);
        }


        /// <summary>
        /// Retorna um cliente específico pelo ID.
        /// </summary>
        /// <param name="id">ID do cliente.</param>
        /// <returns>Objeto cliente.</returns>
        /// <response code="200">Cliente encontrado.</response>
        /// <response code="404">Cliente não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        /// <summary>
        /// Atualiza um cliente existente.
        /// </summary>
        /// <param name="id">ID do cliente a ser atualizado.</param>
        /// <param name="cliente">Dados atualizados do cliente.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="200">Cliente atualizado com sucesso.</response>
        /// <response code="404">Cliente não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPut("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            var existingCliente = _clienteRepository.GetById(id);
            if (existingCliente == null)
            {
                return NotFound();
            }

            cliente.Id = id; // Ensuring the ID is consistent
            _clienteRepository.Update(cliente);
            return Ok();
        }

        /// <summary>
        /// Exclui um cliente pelo ID.
        /// </summary>
        /// <param name="id">ID do cliente a ser excluído.</param>
        /// <returns>Status da operação.</returns>
        /// <response code="204">Cliente excluído com sucesso.</response>
        /// <response code="404">Cliente não encontrado.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public IActionResult Delete(int id)
        {
            var cliente = _clienteRepository.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _clienteRepository.Delete(cliente);
            return NoContent();
        }
    }
}
