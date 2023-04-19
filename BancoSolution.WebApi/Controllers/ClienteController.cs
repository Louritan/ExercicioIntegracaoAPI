using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BancoSolution.Domain;
using BancoSolution.Infra.Data;

namespace BancoSolution.WebApi.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController()
        {
            _clienteRepository = new ClienteRepository();
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
            var listaClientes = _clienteRepository.BuscarTodosClientes();

            if (listaClientes.Count == 0)
            {
                return BadRequest("Nenhum cliente foi encontrado!");
            }
            
            return Ok(listaClientes);
        }

        [HttpGet("{cpf}")]
        public IActionResult GetCliente(long cpf)
        {
            var clienteBuscado = _clienteRepository.BuscarClientePorCpf(cpf);

            if (clienteBuscado == null)
            {
                return BadRequest("Cliente não foi encontrado!");
            }

            return Ok(clienteBuscado);
        }
    }
}