using FinanceiroNucleo.Negocio;
using FinanceiroNucleo.Repositorios.Data;
using FinanceiroNucleo.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace FinanceiroNucleo.Repositorios
{
    public class ContaAPagarRepository : IRepository<ContaAPagar>
    {
        private readonly FinanceiroContext _context;

        public ContaAPagarRepository(FinanceiroContext financeiroContext)
        {
            _context = financeiroContext;
        }

        public IUnitOfWork UnitOfWork => _context;


        public void Adicionar(ContaAPagar dominio)
        {
            _context.ContasAPagar.Add(dominio);
        }

        public void Excluir(int id)
        {
            var contaAPagar = _context.ContasAPagar.Find(id);
            _context.ContasAPagar.Remove(contaAPagar);
        }

        public void Atualizar(ContaAPagar dominio)
        {
            _context.ContasAPagar.Update(dominio);
        }

        public ContaAPagar ObterPorId(int id)
        {
          return  _context.ContasAPagar.Find(id);
        }

        public List<ContaAPagar> ObterTodos()
        {
            return _context.ContasAPagar.AsNoTracking().ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
