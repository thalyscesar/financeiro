using Delivery.Tests.Fixtures;
using System;
using Xunit;

namespace Delivery.Tests
{
    [Collection(nameof(ContaAPagarCollection))]
    public class ContaAPagarTeste
    {
        private readonly ContaAPagarFixture _contaAPagarFixture;

        public ContaAPagarTeste(ContaAPagarFixture contaAPagarFixture)
        {
            _contaAPagarFixture = contaAPagarFixture;
        }

        [Fact]
        public void ContaAPagar_ContaEstaEmAtraso_DeveEstarEmAtraso()
        {
            // Arrange
            var contaAPagar = _contaAPagarFixture.CriarContaAPagarEmAtraso();

            // Action
            var estaEmAtrazo = contaAPagar.ContaEstaEmAtraso();

            Assert.True(estaEmAtrazo);
        }

        [Fact]
        public void ContaAPagar_ContaEstaEmAtraso_NaoDeveEstarEmAtrazo()
        {
            // Arrange
            var contaAPagar = _contaAPagarFixture.CriarContaAPagarComPagamentoSemExpirar();

            // Action
            var estaEmAtrazo = contaAPagar.ContaEstaEmAtraso();

            Assert.False(estaEmAtrazo);
        }

        [Fact]
        public void ContaAPagar_ObterQuantidadeDeDiasEmAtraso_DeveEstarCom3DiasEmAtraso()
        {
            // Arrange
            var contaAPagar = _contaAPagarFixture.CriarContaAPagarEmAtraso();

            // Action
            contaAPagar.CalcularDiasEmAtraso();
            int diasEmAtraso = contaAPagar.DiasEmAtraso;

            Assert.Equal(3, diasEmAtraso);
        }

        [Fact]
        public void ContaAPagar_CalcularValorCobrado_DeveEstarSemAtrasoComValorOriginal()
        {
            // Arrange
            var contaAPagar = _contaAPagarFixture.CriarContaAPagarValidaSemAtraso();

            // Action
            contaAPagar.CalcularValorCobrado();

            Assert.Equal(500, contaAPagar.ValorCobrado);
        }


        [Fact]
        public void ContaAPagar_CalcularValorCobrado_DeveEstarEm5DiasDeAtrasoEAcrecidoDeMultaEJuros()
        {
            // Arrange
            var contaAPagar = _contaAPagarFixture.CriarContaAPagarValidaComAtrazo();

            // Action
            contaAPagar.CalcularValorCobrado();

            Assert.Equal(520.54m, Convert.ToDecimal(contaAPagar.ValorCobrado.ToString("N2")));
        }
    }
}
