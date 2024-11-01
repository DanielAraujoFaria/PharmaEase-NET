using Xunit;
using Moq;
using Pharmaease.Services.Services;
using Pharmaease.Repository.Interface;
using Pharmaease.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Pharmaease.Tests.Services
{
    public class ClientesServiceTest
    {
        private readonly Mock<IRepository<Cliente>> _mockRepository;
        private readonly ClientesService _clientesService;

        public ClientesServiceTest()
        {
            _mockRepository = new Mock<IRepository<Cliente>>();
            _clientesService = new ClientesService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllClientsAsync_ReturnsAllClients()
        {
            // Arrange
            var clients = new List<Cliente>
            {
                new Cliente { Id = 1, IdCliente = 1, Nome = "Client 1", CPF = "123.456.789-00" },
                new Cliente { Id = 2, IdCliente = 2, Nome = "Client 2", CPF = "987.654.321-00" }
            };
            _mockRepository.Setup(repo => repo.GetAll()).Returns(clients);

            // Act
            var result = await _clientesService.GetAllClientsAsync();

            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetClientByIdAsync_ReturnsClient_WhenClientExists()
        {
            // Arrange
            var client = new Cliente { Id = 1, IdCliente = 1, Nome = "Client 1", CPF = "123.456.789-00" };
            _mockRepository.Setup(repo => repo.GetById(1)).Returns(client);

            // Act
            var result = await _clientesService.GetClientByIdAsync(1);

            // Assert
            Assert.Equal(client, result);
        }

        [Fact]
        public async Task CreateClientAsync_AddsClient()
        {
            // Arrange
            var client = new Cliente { Id = 1, IdCliente = 1, Nome = "Client 1", CPF = "123.456.789-00" };

            // Act
            await _clientesService.CreateClientAsync(client);

            // Assert
            _mockRepository.Verify(repo => repo.Add(client), Times.Once);
        }

        [Fact]
        public async Task UpdateClientAsync_UpdatesClient()
        {
            // Arrange
            var client = new Cliente { Id = 1, IdCliente = 1, Nome = "Client 1", CPF = "123.456.789-00" };

            // Act
            await _clientesService.UpdateClientAsync(client);

            // Assert
            _mockRepository.Verify(repo => repo.Update(client), Times.Once);
        }

        [Fact]
        public async Task DeleteClientAsync_DeletesClient_WhenClientExists()
        {
            // Arrange
            var client = new Cliente { Id = 1, IdCliente = 1, Nome = "Client 1", CPF = "123.456.789-00" };
            _mockRepository.Setup(repo => repo.GetById(1)).Returns(client);

            // Act
            await _clientesService.DeleteClientAsync(1);

            // Assert
            _mockRepository.Verify(repo => repo.Delete(client), Times.Once);
        }

        [Fact]
        public async Task DeleteClientAsync_DoesNotDelete_WhenClientDoesNotExist()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetById(It.IsAny<int>())).Returns((Cliente)null); 

            // Act
            await _clientesService.DeleteClientAsync(1);

            // Assert
            _mockRepository.Verify(repo => repo.Delete(It.IsAny<Cliente>()), Times.Never);
        }

    }
}
