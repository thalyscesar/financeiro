using FinanceiroNucleo.Negocio;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Delivery.Tests.Fixtures
{
    [CollectionDefinition(nameof(ContaAPagarCollection))]
    public class ContaAPagarCollection : ICollectionFixture<ContaAPagarFixture>
    {

    }

    public class ContaAPagarFixture : IDisposable
    {

        public ContaAPagar CriarContaAPagarEmAtraso()
        {
            return new ContaAPagar()
            {
                DataPagamento = DateTime.Now.AddDays(3),
                DataVencimento = DateTime.Now
            };
        }

        public ContaAPagar CriarContaAPagarComPagamentoSemExpirar()
        {
            return new ContaAPagar()
            {
                DataPagamento = DateTime.Now,
                DataVencimento = DateTime.Now
            };
        }

        public ContaAPagar CriarContaAPagarValidaSemAtraso()
        {
            return new ContaAPagar()
            {
                DataPagamento = DateTime.Now,
                DataVencimento = DateTime.Now,
                Nome = "Conta despesas de casa",
                ValorOriginal = 500
            };
        }

        public ContaAPagar CriarContaAPagarValidaComAtrazo()
        {
            return new ContaAPagar()
            {
                DataPagamento = DateTime.Now.AddDays(5),
                DataVencimento = DateTime.Now,
                Nome = "Conta despesas de casa",
                ValorOriginal = 500.5m
            };
        }

        public void Dispose()
        {
        }
    }
}
