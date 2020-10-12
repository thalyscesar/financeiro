using FinanceiroNucleo.Models;
using FluentValidation;
using System;

namespace FinanceiroNucleo.Validadores
{
    public class ValidadorContaAPagar: AbstractValidator<ContaAPagarModel>
    {
        public ValidadorContaAPagar()
        {
            RuleFor(c => c.Nome).NotNull().NotEmpty().WithMessage("Nome deve ser obrigatorio.");
            RuleFor(c => c.Nome).MinimumLength(1).WithMessage("Nome deve ter no minimo um caracter");
            RuleFor(c => c.DataPagamento).NotEqual(DateTime.MinValue).WithMessage("Datade  pagamento deve ser obrigatorio.");
            RuleFor(c => c.DataVencimento).NotEqual(DateTime.MinValue).WithMessage("Data de vencimento deve ser obrigatorio.");
            RuleFor(c => c.ValorOriginal).GreaterThan(0).WithMessage("Valor deve ser maior que 0.");
        }
    }
}
