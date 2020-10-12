using FinanceiroNucleo.Models;
using FinanceiroNucleo.Servicos.Interfaces;
using FinanceiroNucleo.Validadores.Excecoes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaAPagarController : ControllerBase
    {
        private readonly IContaAPagarService _contaAPagarService;

        public ContaAPagarController(IContaAPagarService contaAPagarService)
        {
            _contaAPagarService = contaAPagarService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContaAPagarModel model)
        {
            try
            {
                var id = _contaAPagarService.Adicionar(model);
                if (id > 0)
                    return Created(new Uri(Request.Path,UriKind.Relative), new { id });
            }
            catch (ValidacaoException vex)
            {
                return BadRequest(vex.Message);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }

            return null;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var contasAPagarModel = _contaAPagarService.ObterTodos();
            if (contasAPagarModel.Count == 0) return NoContent();
            return Ok(contasAPagarModel);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ContaAPagarModel model = _contaAPagarService.ObterPorId(id);
            if (model == null) NotFound();
            return Ok(model);
        }

        [HttpPut]
        public IActionResult Put([FromBody] ContaAPagarModel model)
        {
            try
            {
                if (_contaAPagarService.Atualizar(model)) return Ok();
            }
            catch (ValidacaoException vex)
            {
                return BadRequest(vex.Message);
            }
            catch (SqlException ex)
            {
                return BadRequest(ex.Message);
            }
            return null;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_contaAPagarService.Excluir(id))
            {
                return Ok();
            }
            return null;
        }
    }
}
