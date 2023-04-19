using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BancoSolution.Domain;

namespace BancoSolution.Infra.Data
{
    public class ContratoDao
    {
        //@"server=DESKTOP-QQ03OD8;initial catalog=BANCO_DB;integrated security=true;"; uniplac
        //@"server=localhost\SQLEXPRESS;initial catalog=BANCO_DB;integrated security=true;"; casa
        private readonly string _connectionString =
         @"server=DESKTOP-QQ03OD8;initial catalog=BANCO_DB;integrated security=true;";

        public ContratoDao()
        {

        }

        public void Inserir(Contrato novaContrato)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT CONTRATO 
                                    VALUES (@NUMERO, @TIPO_CONTRATO, @QUANTIDADE_PARCELAS, 
                                            @VALOR_TOTAL, @VALOR_PARCELA, @DATA_INICIO,
                                            @DATA_FIM, @CPF_CLIENTE)";

                    comando.Parameters.AddWithValue("@NUMERO", novaContrato.Numero);
                    comando.Parameters.AddWithValue("@TIPO_CONTRATO", novaContrato.TipoContrato);
                    comando.Parameters.AddWithValue("@QUANTIDADE_PARCELAS", novaContrato.QunatidadeParcelas);
                    comando.Parameters.AddWithValue("@VALOR_TOTAL", novaContrato.ValorTotal);
                    comando.Parameters.AddWithValue("@VALOR_PARCELA", novaContrato.ValorParcela);
                    comando.Parameters.AddWithValue("@DATA_INICIO", novaContrato.DataInicio);
                    comando.Parameters.AddWithValue("@DATA_FIM", novaContrato.DataFim);
                    comando.Parameters.AddWithValue("@CPF_CLIENTE", novaContrato.Cliente.CpfCliente);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Contrato> BuscarPorCliente(Cliente cliente)
        {
            var listaContrato = new List<Contrato>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT CT.NUMERO
                                         ,CT.TIPO_CONTRATO
                                         ,CT.QUANTIDADE_PARCELAS
                                         ,CT.TIPO_CONTRATO
                                         ,CT.VALOR_TOTAL
                                         ,CT.VALOR_PARCELA
                                         ,CT.DATA_INICIO
                                         ,CT.DATA_FIM
                                         ,CT.CPF_CLIENTE
                                         ,C.NOME
                                         ,C.DATA_NASCIMENTO
                                    FROM CONTRATO CT
                                    INNER JOIN CLIENTE C 
                                    ON C.CPF = CT.CPF_CLIENTE
                                WHERE CT.CPF_CLIENTE = @CPF_BUSCA";

                    comando.Parameters.AddWithValue("@CPF_BUSCA", cliente.CpfCliente);

                    comando.CommandText = sql;

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var contratoBuscada = new Contrato
                        {
                            Numero = long.Parse(leitor["NUMERO"].ToString()),
                            TipoContrato = (TipoContrato)Convert.ToInt16(leitor["TIPO_CONTRATO"].ToString()),
                            QunatidadeParcelas = int.Parse(leitor["QUANTIDADE_PARCELAS"].ToString()),
                            DataInicio = Convert.ToDateTime(leitor["DATA_INICIO"].ToString()),
                            DataFim = Convert.ToDateTime(leitor["DATA_FIM"].ToString()),
                            ValorTotal = double.Parse(leitor["VALOR_TOTAL"].ToString()),
                            Cliente = new Cliente
                            {
                                CpfCliente = long.Parse(leitor["CPF_CLIENTE"].ToString()),
                                Nome = leitor["NOME"].ToString(),
                                DataNascimento = Convert.ToDateTime(leitor["DATA_NASCIMENTO"].ToString())
                            }
                        };

                        listaContrato.Add(contratoBuscada);
                    }
                }
            }

            return listaContrato;

        }

    }
}
