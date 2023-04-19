using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BancoSolution.Domain;
using BancoSolution.Infra.Data;

namespace BancoSolution.WebApi.Controllers
{
    [ApiController]
    [Route("api/contratos")]
    public class ContratoController : ControllerBase
    {
        private readonly IContratoRepository _contratoRepository;

        public ContratoController()
        {
            _contratoRepository = new ContratoRepository();
        }

        [HttpGet("{cpf}")]
        public IActionResult GetContratosPorCliente(long cpf)
        {
            var listaContratos = _contratoRepository.BuscarContratosPorCliente(cpf);

            if (listaContratos.Count == 0)
            {
                return BadRequest("Nenhum contrato foi encontrado!");
            }
            
            return Ok(listaContratos);
        }

        [HttpPost]
        public IActionResult PostContrato(Contrato novoContrato)
        {
            _contratoRepository.CadastraNovoContrato(novoContrato);
            return Ok();
        }
    }
}