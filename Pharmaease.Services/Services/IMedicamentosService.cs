using Pharmaease.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmaease.Services.Services
{
    public interface IMedicamentosService
    {
        Task<IEnumerable<Medicamento>> GetAllMedicamentosAsync();
        Task<Medicamento> GetMedicamentosByIdAsync(int id);
        Task<Medicamento> CreateMedicamentosAsync(Medicamento medicamento);
        Task UpdateMedicamentosAsync(Medicamento medicamento);
        Task DeleteMedicamentosAsync(int id);
    }
}
