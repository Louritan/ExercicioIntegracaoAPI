using System;

namespace BancoSolution.Domain
{
    public class Contrato
    {
        public long Numero { get; set; }
        public TipoContrato TipoContrato { get; set; }
        public int QunatidadeParcelas { get; set; }
        public double ValorTotal { get; set; }
        public double ValorParcela { get {return CalcularValorParcelas();}  }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Cliente Cliente { get; set; }


        public override string ToString()
        {
            return $"Contrato: {Numero}- Tipo Contrato: {RetornarTipoContrato()}" +
                   $"\nQuantidade Parcelas: {QunatidadeParcelas} - Valor total: {ValorTotal}\n " +
                   $"\nValorParcela: {ValorParcela} - Data Início: {DataInicio}\n " +
                   $"\nData Fim: {DataInicio} - Cliente: {Cliente.Nome} CPF: {Cliente.CpfCliente} ";
        }

        public Contrato()
        {
            Cliente = new Cliente();
            DataInicio = DateTime.Now;
            CalcularDataFinal();
        }

        public void CalcularDataFinal()
        {
            DataFim = DataInicio.AddMonths(QunatidadeParcelas);
        }

        private double CalcularValorParcelas()
        {
            return ValorTotal / QunatidadeParcelas;
        }

        private string RetornarTipoContrato()
        {
            var tipoContrato = 
              TipoContrato == TipoContrato.Consignado ? "Consignado" 
            : TipoContrato == TipoContrato.CDC ? "CDC" 
            : "Habitacional";

            return $"tipoContrato";
        }

    }

    public enum TipoContrato
    {
        Consignado = 1,
        CDC = 2,
        Habitacional = 3
    }
}