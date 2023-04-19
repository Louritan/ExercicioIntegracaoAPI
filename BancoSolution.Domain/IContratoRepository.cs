using System;
using System.Collections.Generic;

namespace BancoSolution.Domain
{
    public interface IContratoRepository
    {

        /// <summary>
        /// Busca contratos pelo CPF
        /// </summary>
        /// <param name="novaContrato"></param>
        /// <returns> Lista de contratos </returns>
        void CadastraNovoContrato(Contrato novaContrato);  

        /// <summary>
        /// Busca contratos pelo NUMERO
        /// </summary>
        /// <param name="numerContrato"></param>
        /// <returns> Uma ou mais contratos </returns>
         List<Contrato>  BuscarContratosPorCliente(long cpfCliente);    
   
    }
}