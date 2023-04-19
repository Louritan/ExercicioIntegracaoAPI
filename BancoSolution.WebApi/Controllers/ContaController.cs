using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BancoSolution.Domain;
using BancoSolution.Infra.Data;

namespace BancoSolution.WebApi.Controllers
{
    [ApiController]
    [Route("api/contas")]
    public class ContaController : ControllerBase
    {
        private readonly IContaRepository _contaRepository;

        public ContaController()
        {
            _contaRepository = new ContaRepository();
        }

        [HttpGet]
        public IActionResult GetContas()
        {
            var listaContas = _contaRepository.BuscarTodasContas();

            if (listaContas.Count == 0)
            {
                return BadRequest("Nenhuma conta foi encontrada!");
            }
            
            return Ok(listaContas);
        }

        [HttpGet("{cpf}")]
        public IActionResult GetContasPorCliente(long cpf)
        {
            var listaContas = _contaRepository.BuscarContasPorCliente(cpf);

            if (listaContas.Count == 0)
            {
                return BadRequest("Nenhuma conta foi encontrada!");
            }
            
            return Ok(listaContas);
        }

        [HttpPost]
        public IActionResult PostConta(Conta novaConta)
        {
            _contaRepository.CadastraNovaConta(novaConta);
            return Ok();
        }
    }
}