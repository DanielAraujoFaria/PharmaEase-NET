using Pharmaease.Repository.Interface;
using Pharmaease.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmaease.Services.Services
{
    public class ClientesService : IClientesService
    {
        private readonly IRepository<Cliente> _clienteRepository;

        public ClientesService(IRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Task<IEnumerable<Cliente>> GetAllClientsAsync()
        {
            return Task.Run(() => _clienteRepository.GetAll());
        }

        public Task<Cliente> GetClientByIdAsync(int id)
        {
            return Task.Run(() => _clienteRepository.GetById(id));
        }

        public Task CreateClientAsync(Cliente cliente)
        {
            return Task.Run(() => _clienteRepository.Add(cliente));
        }

        public Task UpdateClientAsync(Cliente cliente)
        {
            return Task.Run(() => _clienteRepository.Update(cliente));
        }

        public Task DeleteClientAsync(int id)
        {
            return Task.Run(() => {
                var cliente = _clienteRepository.GetById(id);
                if (cliente != null)
                {
                    _clienteRepository.Delete(cliente);
                }
            });
        }

        public Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetClienteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> CreateClienteAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClienteAsync(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClienteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
