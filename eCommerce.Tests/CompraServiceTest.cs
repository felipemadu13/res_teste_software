using System.Collections.Generic;
using ecommerce.Services;
using eCommerce.Domain.Entity;
using Ecommerce.Entity;

namespace Xunit.Coverlet
{
    public class CompraServiceTest
    {

        private readonly CompraService _service;

        public CompraServiceTest() => _service = new CompraService();


        [Theory]
        //MENOR OU IGUAL A 5KG:
            //OURO:
                // VALOR MENOR OU IGUAL A 500
                [InlineData(TipoCliente.OURO, 5, 500, 500)] 
                // VALOR ENTRE 500 E 1000
                [InlineData(TipoCliente.OURO, 5, 501, 450.9)] 
                [InlineData(TipoCliente.OURO, 5, 1000, 900)] 
                // VALOR MAIOR QUE 1000
                [InlineData(TipoCliente.OURO, 5, 1001, 800.8)] 
            //PRATA:
                // VALOR MENOR OU IGUAL A 500
                [InlineData(TipoCliente.PRATA, 5, 500, 500)] 
                // VALOR ENTRE 500 E 1000
                [InlineData(TipoCliente.PRATA, 5, 501, 450.9)] 
                [InlineData(TipoCliente.PRATA, 5, 1000, 900)]
                // VALOR MAIOR QUE 1000
                [InlineData(TipoCliente.PRATA, 5, 1001, 800.8)] 
            //BRONZE:
                // VALOR MENOR OU IGUAL A 500
                [InlineData(TipoCliente.BRONZE, 5, 500, 500)] 
                // VALOR ENTRE 500 E 1000
                [InlineData(TipoCliente.BRONZE, 5, 501, 450.9)] 
                [InlineData(TipoCliente.BRONZE, 5, 1000, 900)]
                // VALOR MAIOR QUE 1000
                [InlineData(TipoCliente.BRONZE, 5, 1001, 800.8)] 
        //ENTRE 5 E 10KG:
            //OURO:
                // VALOR MENOR OU IGUAL A 500
                [InlineData(TipoCliente.OURO, 6, 500, 500)] 
                [InlineData(TipoCliente.OURO, 10, 500, 500)] 
                // VALOR ENTRE 500 E 1000
                [InlineData(TipoCliente.OURO, 6, 501, 450.9)] 
                [InlineData(TipoCliente.OURO, 6, 1000, 900)] 
                [InlineData(TipoCliente.OURO, 10, 501, 450.9)] 
                [InlineData(TipoCliente.OURO, 10, 1000, 900)] 
                // VALOR MAIOR QUE 1000
                [InlineData(TipoCliente.OURO, 6, 1001, 800.8)] 
                [InlineData(TipoCliente.OURO, 10, 1001, 800.8)] 
            //PRATA:
                // VALOR MENOR OU IGUAL A 500
                [InlineData(TipoCliente.PRATA, 6, 500, 506)] 
                [InlineData(TipoCliente.PRATA, 10, 500, 510)] 
                // VALOR ENTRE 500 E 1000
                [InlineData(TipoCliente.PRATA, 6, 501, 456.9)] 
                [InlineData(TipoCliente.PRATA, 6, 1000, 906)] 
                [InlineData(TipoCliente.PRATA, 10, 501, 460.9)] 
                [InlineData(TipoCliente.PRATA, 10, 1000, 910)] 
                // VALOR MAIOR QUE 1000
                [InlineData(TipoCliente.PRATA, 6, 1001, 806.8)] 
                [InlineData(TipoCliente.PRATA, 10, 1001, 810.8)] 
            //BRONZE:
                // VALOR MENOR OU IGUAL A 500
                [InlineData(TipoCliente.BRONZE, 6, 500, 512)] 
                [InlineData(TipoCliente.BRONZE, 10, 500, 520)] 
                // VALOR ENTRE 500 E 1000
                [InlineData(TipoCliente.BRONZE, 6, 501, 462.9)] 
                [InlineData(TipoCliente.BRONZE, 6, 1000, 912)] 
                [InlineData(TipoCliente.BRONZE, 10, 501, 470.9)] 
                [InlineData(TipoCliente.BRONZE, 10, 1000, 920)] 
                // VALOR MAIOR QUE 1000
                [InlineData(TipoCliente.BRONZE, 6, 1001, 812.8)] 
                [InlineData(TipoCliente.BRONZE, 10, 1001, 820.8)] 
        //ENTRE 10 E 50KG:
            //OURO:
                // VALOR MENOR OU IGUAL A 500
                [InlineData(TipoCliente.OURO, 11, 500, 500)] 
                [InlineData(TipoCliente.OURO, 50, 500, 500)] 
                // VALOR ENTRE 500 E 1000
                [InlineData(TipoCliente.OURO, 11, 501, 450.9)] 
                [InlineData(TipoCliente.OURO, 11, 1000, 900)] 
                [InlineData(TipoCliente.OURO, 50, 501, 450.9)] 
                [InlineData(TipoCliente.OURO, 50, 1000, 900)] 
                // VALOR MAIOR QUE 1000
                [InlineData(TipoCliente.OURO, 11, 1001, 800.8)] 
                [InlineData(TipoCliente.OURO, 50, 1001, 800.8)] 
            //PRATA:
                // VALOR MENOR OU IGUAL A 500
                [InlineData(TipoCliente.PRATA, 11, 500, 522)] 
                [InlineData(TipoCliente.PRATA, 50, 500, 600)] 
                // VALOR ENTRE 500 E 1000
                [InlineData(TipoCliente.PRATA, 11, 501, 472.9)] 
                [InlineData(TipoCliente.PRATA, 11, 1000, 922)] 
                [InlineData(TipoCliente.PRATA, 50, 501, 550.9)] 
                [InlineData(TipoCliente.PRATA, 50, 1000, 1000)] 
                // VALOR MAIOR QUE 1000
                [InlineData(TipoCliente.PRATA, 11, 1001, 822.8)] 
                [InlineData(TipoCliente.PRATA, 50, 1001, 900.8)] 
            //BRONZE:
                // VALOR MENOR OU IGUAL A 500
                [InlineData(TipoCliente.BRONZE, 11, 500, 544)] 
                [InlineData(TipoCliente.BRONZE, 50, 500, 700)] 
                // VALOR ENTRE 500 E 1000
                [InlineData(TipoCliente.BRONZE, 11, 501, 494.9)] 
                [InlineData(TipoCliente.BRONZE, 11, 1000, 944)] 
                [InlineData(TipoCliente.BRONZE, 50, 501, 650.9)] 
                [InlineData(TipoCliente.BRONZE, 50, 1000, 1100)] 
                // VALOR MAIOR QUE 1000
                [InlineData(TipoCliente.BRONZE, 11, 1001, 844.8)] 
                [InlineData(TipoCliente.BRONZE, 50, 1001, 1000.8)] 
        //MAIOR QUE 50 KG:
            //OURO:
                // VALOR MENOR OU IGUAL A 500
                [InlineData(TipoCliente.OURO, 51, 500, 500)] 
                // VALOR ENTRE 500 E 1000
                [InlineData(TipoCliente.OURO, 51, 501, 450.9)] 
                [InlineData(TipoCliente.OURO, 51, 1000, 900)] 
                // VALOR MAIOR QUE 1000
                [InlineData(TipoCliente.OURO, 51, 1001, 800.8)] 
            //PRATA:
                // VALOR MENOR OU IGUAL A 500
                [InlineData(TipoCliente.PRATA, 51, 500, 678.5)] 
                // VALOR ENTRE 500 E 1000
                [InlineData(TipoCliente.PRATA, 51, 501, 629.4)] 
                [InlineData(TipoCliente.PRATA, 51, 1000, 1078.5)] 
                // VALOR MAIOR QUE 1000
                [InlineData(TipoCliente.PRATA, 51, 1001, 979.3)] 
            //BRONZE:
                // VALOR MENOR OU IGUAL A 500
                [InlineData(TipoCliente.BRONZE, 51, 500, 857)] 
                // VALOR ENTRE 500 E 1000
                [InlineData(TipoCliente.BRONZE, 51, 501, 807.9)] 
                [InlineData(TipoCliente.BRONZE, 51, 1000, 1257)] 
                // VALOR MAIOR QUE 1000
                [InlineData(TipoCliente.BRONZE, 51, 1001, 1157.8)] 
        public void CalcularCustoTotalTest(
            TipoCliente tipoCliente, decimal pesoTotal, decimal valorTotalItens, decimal valorEsperado)
        {
            // Arrange
            var carrinho = CriarCarrinhoDeCompras(tipoCliente, pesoTotal, valorTotalItens);

            // Act
            var resultado = _service.CalcularCustoTotal(carrinho);

            // Assert
            Assert.Equal(valorEsperado, resultado);
        }

        private CarrinhoDeCompras CriarCarrinhoDeCompras(TipoCliente tipoCliente, decimal pesoTotal, decimal valorTotalItens)
        {
            var cliente = new Cliente { Tipo = tipoCliente };
            var produto = new Produto { Peso = (int)pesoTotal, Preco = valorTotalItens };
            var item = new ItemCompra { Produto = produto, Quantidade = 1 };
            return new CarrinhoDeCompras
            {
                Cliente = cliente,
                Itens = new List<ItemCompra> { item }
            };
        }
    }
}
