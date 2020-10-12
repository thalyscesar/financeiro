using FinanceiroNucleo.Models;
using FinanceiroNucleo.Negocio;
using FinanceiroNucleo.Repositorios.Interfaces;
using FinanceiroNucleo.Servicos.Interfaces;
using FinanceiroNucleo.Validadores;
using FinanceiroNucleo.Validadores.Excecoes;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinanceiroNucleo.Servicos
{
    public class ContaAPagarService : IContaAPagarService
    {
        private readonly IRepository<ContaAPagar> _contaAPagarRepository;

        public ContaAPagarService(IRepository<ContaAPagar> repository)
        {
            _contaAPagarRepository = repository;
        }

        public int Adicionar(ContaAPagarModel model)
        {
            ValidarAtualizacaoOUAdicao(model);

            var contaAPagar = ToDomain(model);
            contaAPagar.CalcularValorCobrado();

            _contaAPagarRepository.Adicionar(contaAPagar);
            if (_contaAPagarRepository.UnitOfWork.Commit()) 
            {
                return contaAPagar.Id;
            }
            return 0;
        }

        public bool Atualizar(ContaAPagarModel model)
        {
            ValidarAtualizacaoOUAdicao(model);

            var contaAPagar = ToDomain(model);
            contaAPagar.CalcularValorCobrado();

            _contaAPagarRepository.Atualizar(contaAPagar);
            return _contaAPagarRepository.UnitOfWork.Commit();
        }

        public bool Excluir(int id)
        {
            _contaAPagarRepository.Excluir(id);
            return _contaAPagarRepository.UnitOfWork.Commit();
        }

        public ContaAPagarModel ObterPorId(int id)
        {
            ContaAPagar contaAPagar = _contaAPagarRepository.ObterPorId(id);
            return ToModel(contaAPagar);
            
        }

        public List<ContaAPagarListagemModel> ObterTodos()
        {
            List<ContaAPagar> contasAPagar = _contaAPagarRepository.ObterTodos();
            return contasAPagar.Select(c => ToListategemModel(c)).ToList();
        }

        public ContaAPagarModel ToModel(ContaAPagar contaAPagar)
        {
            return new ContaAPagarModel()
            {
                Id = contaAPagar.Id,
                DataPagamento = contaAPagar.DataPagamento,
                DataVencimento = contaAPagar.DataVencimento,
                Nome = contaAPagar.Nome,
                ValorOriginal = contaAPagar.ValorOriginal
            };
        }

        public ContaAPagar ToDomain(ContaAPagarModel model)
        {
            return new ContaAPagar()
            {
                Id = model.Id,
                Nome = model.Nome,
                DataPagamento = model.DataPagamento,
                DataVencimento = model.DataVencimento,
                ValorOriginal = model.ValorOriginal
            };
        }

        public ContaAPagarListagemModel ToListategemModel(ContaAPagar contaAPagar)
        {
            

            return new ContaAPagarListagemModel()
            {
                Id = contaAPagar.Id,
                DataPagamento = contaAPagar.DataPagamento,
                Nome = contaAPagar.Nome,
                QuantidadeDiasAtraso = contaAPagar.DiasEmAtraso,
                ValorCorrigido = contaAPagar.ValorCobrado,
                ValorOriginal = contaAPagar.ValorOriginal
            };
        }

        public void Dispose()
        {
            _contaAPagarRepository.Dispose();
        }

        public void ValidarAtualizacaoOUAdicao(ContaAPagarModel contaAPagarModel)
        {
            ValidadorContaAPagar validador = new ValidadorContaAPagar();
            ValidationResult result = validador.Validate(contaAPagarModel);
            if (!result.IsValid)
                throw new ValidacaoException(result);
        }
    }
}
