using System;

using System.Threading.Tasks;

// using ecommerce.Controllers;

using ecommerce.Services;

using eCommerce.Domain.DTO;

using Microsoft.AspNetCore.Mvc;

using Moq;

using Xunit;



namespace eCommerce.Tests

{

    public class CompraControllerTest

    {

        private readonly Mock<CompraService> _mockService;

        private readonly CompraController _controller;



        public CompraControllerTest()

        {

            _mockService = new Mock<CompraService>();

            _controller = new CompraController(_mockService.Object);

        }



        [Fact]

        public async Task FinalizarCompra_Success_ReturnsOk()

        {

            // Arrange

            var compraDTO = new CompraDTO(true, null, "Compra realizada com sucesso.");

            _mockService.Setup(s => s.FinalizarCompraAsync(It.IsAny<long>(), It.IsAny<long>())).ReturnsAsync(compraDTO);



            // Act

            var result = await _controller.FinalizarCompra(1, 1);



            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            Assert.Equal(compraDTO, okResult.Value);

        }



        [Fact]

        public async Task FinalizarCompra_ArgumentException_ReturnsBadRequest()

        {

            // Arrange

            _mockService.Setup(s => s.FinalizarCompraAsync(It.IsAny<long>(), It.IsAny<long>())).ThrowsAsync(new ArgumentException("Argumento inválido"));



            // Act

            var result = await _controller.FinalizarCompra(1, 1);



            // Assert

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);

            Assert.Equal("Argumento inválido", ((CompraDTO)badRequestResult.Value).Mensagem);

        }



        [Fact]

        public async Task FinalizarCompra_InvalidOperationException_ReturnsConflict()

        {

            // Arrange

            _mockService.Setup(s => s.FinalizarCompraAsync(It.IsAny<long>(), It.IsAny<long>())).ThrowsAsync(new InvalidOperationException("Operação inválida"));



            // Act

            var result = await _controller.FinalizarCompra(1, 1);



            // Assert

            var conflictResult = Assert.IsType<ConflictObjectResult>(result.Result);

            Assert.Equal("Operação inválida", ((CompraDTO)conflictResult.Value).Mensagem);

        }



        [Fact]

        public async Task FinalizarCompra_Exception_ReturnsInternalServerError()

        {

            // Arrange

            _mockService.Setup(s => s.FinalizarCompraAsync(It.IsAny<long>(), It.IsAny<long>())).ThrowsAsync(new Exception());



            // Act

            var result = await _controller.FinalizarCompra(1, 1);



            // Assert

            var internalServerErrorResult = Assert.IsType<ObjectResult>(result.Result);

            Assert.Equal(500, internalServerErrorResult.StatusCode);

            Assert.Equal("Erro ao processar compra.", ((CompraDTO)internalServerErrorResult.Value).Mensagem);

        }

    }

}