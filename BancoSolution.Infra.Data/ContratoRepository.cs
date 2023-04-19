using System;
using System.Collections.Generic;
using BancoSolution.Domain;

namespace BancoSolution.Infra.Data
{
    public class ContratoRepository : IContratoRepository
    {
        private readonly ContratoDao _contratoDao;
        private readonly ClienteDao _clienteDao;

        public ContratoRepository()
        {
            _contratoDao = new ContratoDao();
            _clienteDao = new ClienteDao();
        }

        public void CadastraNovoContrato(Contrato novaContrato)
        {
            _contratoDao.Inserir(novaContrato);
        }

        public List<Contrato> BuscarContratosPorCliente(long cpfCliente)
        {
            var clienteEncontrado = _clienteDao.BuscarPorCpf(cpfCliente);

            if (clienteEncontrado.CpfCliente == 0)
                throw new Exception("Cliente não encontrado!");
                
            return _contratoDao.BuscarPorCliente(clienteEncontrado);
        }
    }
}
