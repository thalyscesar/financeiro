using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceiroNucleo.Repositorios.Interfaces
{
   public interface IRepository<T> : IDisposable where T : class
    {
        IUnitOfWork UnitOfWork { get; }

        void Adicionar(T dominio);
        void Excluir(int id);
        void Atualizar(T dominio);
        T ObterPorId(int id);
        List<T> ObterTodos();
    }
}
