using Pharmaease.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmaease.Services.Services
{
    public interface IClientesService
    {
        Task<IEnumerable<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<Cliente> CreateClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(Cliente cliente);
        Task DeleteClienteAsync(int id);
    }
}
