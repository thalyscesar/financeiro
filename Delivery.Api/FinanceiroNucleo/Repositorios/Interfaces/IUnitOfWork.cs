using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceiroNucleo.Repositorios.Interfaces
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}
