using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinanceiroNucleo.Validadores.Excecoes
{
    public class ValidacaoException: ApplicationException
    {
        public IList<ValidationFailure> Errors { get; private set; }

        public ValidacaoException(ValidationResult validationResult)
        {
            this.Errors = validationResult.Errors;
        }

        public override string Message
        {
            get
            {
                return string.Join("<br>", this.Errors.Select(x => x.ErrorMessage));
            }
        }

        public string FirstErrorMessage
        {
            get
            {
                return this.Errors[0].ErrorMessage;
            }
        }
    }
}
