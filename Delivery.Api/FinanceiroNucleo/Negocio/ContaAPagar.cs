using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;

namespace FinanceiroNucleo.Negocio
{
    public class ContaAPagar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        
        public decimal ValorOriginal { get; set; }
       
        public DateTime DataVencimento { get; set; }
      
        public DateTime DataPagamento { get; set; }
        public decimal ValorMulta { get; private set; }
        public decimal ValorJuros { get; private set; }

       
        public decimal ValorCobrado { get; private set; }
      
        public int DiasEmAtraso { get; private set; }

        public bool ContaEstaEmAtraso()
        {
            return DataPagamento > DataVencimento;
        }

        public void CalcularDiasEmAtraso()
        {
            if (!ContaEstaEmAtraso()) DiasEmAtraso = 0;

            DiasEmAtraso = (int)DataPagamento.Subtract(DataVencimento).Days;
            if(DiasEmAtraso < 0) 
            {
                DiasEmAtraso = 0;
            }
        }

        public void CalcularValorCobrado()
        {
            CalcularDiasEmAtraso();

            if (DiasEmAtraso == 0)
            {
                ValorCobrado = ValorOriginal;
                return;
            }

            //taxa 2 %
            if (DiasEmAtraso <= 3)
            {
                CalcularValorMulta(2);
                CalcularJuros(0.1m);
            }
            /// taxa 3%
            else if (DiasEmAtraso > 3 && DiasEmAtraso <= 5)
            {
                CalcularValorMulta(3);
                CalcularJuros(0.2m);
            }
            // taxa 5%
            else
            {
                CalcularValorMulta(5);
                CalcularJuros(0.3m);
            }

            ValorCobrado = ValorOriginal + ValorMulta + ValorJuros;
        }

        private void CalcularValorMulta(int taxa)
        {
            ValorMulta = (ValorOriginal * taxa) / 100;
        }

        private void CalcularJuros(decimal taxa)
        {
            var juroComposto = (double)(1 + taxa / 100);
            decimal valorAcumulado = ValorOriginal * (decimal)Math.Pow(juroComposto, Convert.ToDouble(DiasEmAtraso));
            ValorJuros = valorAcumulado - ValorOriginal;
        }
    }
}
