using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceiroNucleo.Models
{
    public class ContaAPagarModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
