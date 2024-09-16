using Pharmaease.Database.Models;
using Pharmaease.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmaease.Services.Services
{
    public class MedicamentosService : IMedicamentosService
    {
        private readonly IRepository<Medicamento> _medicamentoRepository;

        public MedicamentosService(IRepository<Medicamento> medicamentoRepository)
        {
            _medicamentoRepository = medicamentoRepository;
        }

        public Task<IEnumerable<Medicamento>> GetAllMedicamentosAsync()
        {
            return Task.Run(() => _medicamentoRepository.GetAll());
        }

        public Task<Medicamento> GetMedicamentosByIdAsync(int id)
        {
            return Task.Run(() => _medicamentoRepository.GetById(id));
        }

        public Task CreateMedicamentosAsync(Medicamento medicamento)
        {
            return Task.Run(() => _medicamentoRepository.Add(medicamento));
        }

        public Task UpdateMedicamentosAsync(Medicamento medicamento)
        {
            return Task.Run(() => _medicamentoRepository.Update(medicamento));
        }

        public Task DeleteMedicamentosAsync(int id)
        {
            return Task.Run(() => {
                var medicamento = _medicamentoRepository.GetById(id);
                if (medicamento != null)
                {
                    _medicamentoRepository.Delete(medicamento);
                }
            });
        }

        public Task<IEnumerable<Medicamento>> GetAllMedsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Medicamento> GetMedsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Medicamento> CreateMedsAsync(Medicamento medicamento)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMedsAsync(Medicamento medicamento)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMedsAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Medicamento> IMedicamentosService.CreateMedicamentosAsync(Medicamento medicamento)
        {
            throw new NotImplementedException();
        }
    }
}
