using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using Moq;
using Xunit;

using NumeneraCypherBook.Core.Models;
using NumeneraCypherBook.Core.Data;
using NumeneraCypherBook.API.Controllers;

namespace NumeneraCypherBook.TestsX
{
    public class CypherControllerTest
    {
        IQueryable<Cypher> cyphers;

        public CypherControllerTest()
        {
            cyphers = new List<Cypher>
            {
                new Cypher { Id = 1, Name = "Cypher 1"},
                new Cypher { Id = 2, Name = "Cypher 2"},
                new Cypher { Id = 3, Name = "Cypher 3"},
            }.AsQueryable();
        }

        public void Dispose()
        {
            cyphers = null;
        }

        [Fact]
        public void GetCyphers()
        {
            // Given            
            Mock<ICypherRepository> mockRepo = new Mock<ICypherRepository>();
            mockRepo.Setup(repo => repo.Get()).ReturnsAsync(cyphers.ToList());

            CyphersController controller = new CyphersController(mockRepo.Object);

            // When
            IEnumerable<Cypher> results = controller.GetAll();
            List<Cypher> listResults = results.ToList();

            // Then
            Assert.Equal(3, results.Count());
            Assert.Equal(1, listResults[0].Id);
            Assert.Equal("Cypher 1", listResults[0].Name);
            Assert.Equal(2, listResults[1].Id);
            Assert.Equal("Cypher 2", listResults[1].Name);
            Assert.Equal(3, listResults[2].Id);
            Assert.Equal("Cypher 3", listResults[2].Name);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetCypherByIdOk(int id)
        {
            // Given            
            Mock<ICypherRepository> mockRepo = new Mock<ICypherRepository>();
            mockRepo.Setup(repo => repo.Get(It.IsAny<int>())).Returns<int>((i) => { return Task.FromResult(cyphers.FirstOrDefault(c => c.Id == i)); });

            CyphersController controller = new CyphersController(mockRepo.Object);

            // When
            IActionResult result = controller.GetById(id);

            // Then
            Assert.NotNull(result);
            var objectResult = Assert.IsType<ObjectResult>(result);
            Cypher cypherResult = Assert.IsType<Cypher>(objectResult.Value);
            Assert.Equal(id, cypherResult.Id);
        }
        
        [Theory]
        [InlineData(-1)]
        [InlineData(4)]
        public void GetCypherByIdNotFound(int id)
        {
            // Given            
            Mock<ICypherRepository> mockRepo = new Mock<ICypherRepository>();
            mockRepo.Setup(repo => repo.Get(It.IsAny<int>())).Returns<int>((i) => { return Task.FromResult(cyphers.FirstOrDefault(c => c.Id == i)); });

            CyphersController controller = new CyphersController(mockRepo.Object);

            // When
            IActionResult result = controller.GetById(id);

            // Then
            Assert.NotNull(result);
            var objectResult = Assert.IsType<NotFoundResult>(result);
        }
    }
}
