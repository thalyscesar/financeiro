using FinanceiroNucleo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceiroNucleo.Servicos.Interfaces
{
    public interface IContaAPagarService: IDisposable
    {
        int Adicionar(ContaAPagarModel model);
        bool Excluir(int id);
        bool Atualizar(ContaAPagarModel model);
        ContaAPagarModel ObterPorId(int id);
        List<ContaAPagarListagemModel> ObterTodos();
    }
}
