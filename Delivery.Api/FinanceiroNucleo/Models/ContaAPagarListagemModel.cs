using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceiroNucleo.Models
{
    public class ContaAPagarListagemModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorOriginal { get; set; }
        public decimal ValorCorrigido { get; set; }
        public int QuantidadeDiasAtraso { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
