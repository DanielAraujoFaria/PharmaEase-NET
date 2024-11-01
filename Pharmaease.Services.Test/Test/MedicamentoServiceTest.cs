using Moq;
using Pharmaease.Database.Models;
using Pharmaease.Repository.Interface;
using Pharmaease.Services.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Pharmaease.Services.Test
{
    public class MedicamentosServiceTest
    {
        private readonly Mock<IRepository<Medicamento>> _mockRepository;
        private readonly MedicamentosService _medicamentosService;

        public MedicamentosServiceTest()
        {
            _mockRepository = new Mock<IRepository<Medicamento>>();
            _medicamentosService = new MedicamentosService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllMedicamentosAsync_ReturnsAllMedicamentos()
        {
            // Arrange
            var medicamentos = new List<Medicamento>
            {
                new Medicamento { Id = 1, NomeMed = "Medicamento 1", CodBarra = "1234567890123", Fabricante = "Fabricante A", CategoriaMed = "Antibiótico", Dosagem = "500mg", Descricao = "Descrição 1", QuantidadeUni = "30", DimensaoMed = "10x10x2" },
                new Medicamento { Id = 2, NomeMed = "Medicamento 2", CodBarra = "1234567890124", Fabricante = "Fabricante B", CategoriaMed = "Antivirais", Dosagem = "250mg", Descricao = "Descrição 2", QuantidadeUni = "15", DimensaoMed = "5x5x2" }
            };
            _mockRepository.Setup(repo => repo.GetAll()).Returns(medicamentos);

            // Act
            var result = await _medicamentosService.GetAllMedicamentosAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, m => m.NomeMed == "Medicamento 1" && m.CodBarra == "1234567890123");
            Assert.Contains(result, m => m.NomeMed == "Medicamento 2" && m.CodBarra == "1234567890124");
        }

        [Fact]
        public async Task GetMedicamentosByIdAsync_ReturnsMedicamento_WhenExists()
        {
            // Arrange
            var medicamento = new Medicamento { Id = 1, NomeMed = "Medicamento 1", CodBarra = "1234567890123", Fabricante = "Fabricante A", CategoriaMed = "Antibiótico", Dosagem = "500mg", Descricao = "Descrição 1", QuantidadeUni = "30", DimensaoMed = "10x10x2" };
            _mockRepository.Setup(repo => repo.GetById(1)).Returns(medicamento);

            // Act
            var result = await _medicamentosService.GetMedicamentosByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Medicamento 1", result.NomeMed);
            Assert.Equal("1234567890123", result.CodBarra);
            Assert.Equal("Fabricante A", result.Fabricante);
            Assert.Equal("Antibiótico", result.CategoriaMed);
            Assert.Equal("500mg", result.Dosagem);
            Assert.Equal("Descrição 1", result.Descricao);
            Assert.Equal("30", result.QuantidadeUni);
            Assert.Equal("10x10x2", result.DimensaoMed);
        }

        [Fact]
        public async Task GetMedicamentosByIdAsync_ReturnsNull_WhenNotExists()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetById(1)).Returns((Medicamento)null);

            // Act
            var result = await _medicamentosService.GetMedicamentosByIdAsync(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateMedicamentosAsync_AddsMedicamento()
        {
            // Arrange
            var medicamento = new Medicamento { Id = 1, NomeMed = "Medicamento 1", CodBarra = "1234567890123", Fabricante = "Fabricante A", CategoriaMed = "Antibiótico", Dosagem = "500mg", Descricao = "Descrição 1", QuantidadeUni = "30", DimensaoMed = "10x10x2" };

            // Act
            await _medicamentosService.CreateMedicamentosAsync(medicamento);

            // Assert
            _mockRepository.Verify(repo => repo.Add(It.Is<Medicamento>(m =>
                m.Id == 1 &&
                m.NomeMed == "Medicamento 1" &&
                m.CodBarra == "1234567890123" &&
                m.Fabricante == "Fabricante A" &&
                m.CategoriaMed == "Antibiótico" &&
                m.Dosagem == "500mg" &&
                m.Descricao == "Descrição 1" &&
                m.QuantidadeUni == "30" &&
                m.DimensaoMed == "10x10x2"
            )), Times.Once);
        }

        [Fact]
        public async Task UpdateMedicamentosAsync_UpdatesMedicamento()
        {
            // Arrange
            var medicamento = new Medicamento { Id = 1, NomeMed = "Medicamento 1", CodBarra = "1234567890123", Fabricante = "Fabricante A", CategoriaMed = "Antibiótico", Dosagem = "500mg", Descricao = "Descrição 1", QuantidadeUni = "30", DimensaoMed = "10x10x2" };

            // Act
            await _medicamentosService.UpdateMedicamentosAsync(medicamento);

            // Assert
            _mockRepository.Verify(repo => repo.Update(It.Is<Medicamento>(m =>
                m.  Id == 1 &&
                m.NomeMed == "Medicamento 1" &&
                m.CodBarra == "1234567890123" &&
                m.Fabricante == "Fabricante A" &&
                m.CategoriaMed == "Antibiótico" &&
                m.Dosagem == "500mg" &&
                m.Descricao == "Descrição 1" &&
                m.QuantidadeUni == "30" &&
                m.DimensaoMed == "10x10x2"
            )), Times.Once);
        }

        [Fact]
        public async Task DeleteMedicamentosAsync_DeletesMedicamento_WhenExists()
        {
            // Arrange
            var medicamento = new Medicamento { Id = 1, NomeMed = "Medicamento 1", CodBarra = "1234567890123", Fabricante = "Fabricante A", CategoriaMed = "Antibiótico", Dosagem = "500mg", Descricao = "Descrição 1", QuantidadeUni = "30", DimensaoMed = "10x10x2" };
            _mockRepository.Setup(repo => repo.GetById(1)).Returns(medicamento);

            // Act
            await _medicamentosService.DeleteMedicamentosAsync(1);

            // Assert
            _mockRepository.Verify(repo => repo.Delete(medicamento), Times.Once);
        }

        [Fact]
        public async Task DeleteMedicamentosAsync_DoesNotDelete_WhenNotExists()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetById(1)).Returns((Medicamento)null);

            // Act
            await _medicamentosService.DeleteMedicamentosAsync(1);

            // Assert
            _mockRepository.Verify(repo => repo.Delete(It.IsAny<Medicamento>()), Times.Never);
        }
    }
}
