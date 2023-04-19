using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BancoSolution.Domain;

namespace BancoSolution.Infra.Data
{
    public class ContaDao
    {
        //@"server=DESKTOP-QQ03OD8;initial catalog=BANCO_DB;integrated security=true;"; uniplac
        //@"server=localhost\SQLEXPRESS;initial catalog=BANCO_DB;integrated security=true;"; casa
        private readonly string _connectionString =
         @"server=DESKTOP-QQ03OD8;initial catalog=BANCO_DB;integrated security=true;";

        public ContaDao()
        {

        }

        public void Inserir(Conta novaConta)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT CONTA 
                                    VALUES (@NUMERO, @DIGITO, @AGENCIA, 
                                            @TIPO_CONTA, @SALDO, @LIMITE,
                                            @DATA_ABERTURA, @CESTA, @CPF_CLIENTE)";

                    comando.Parameters.AddWithValue("@NUMERO", novaConta.Numero);
                    comando.Parameters.AddWithValue("@DIGITO", novaConta.Digito);
                    comando.Parameters.AddWithValue("@AGENCIA", novaConta.Agencia);
                    comando.Parameters.AddWithValue("@TIPO_CONTA", novaConta.TipoConta);
                    comando.Parameters.AddWithValue("@SALDO", novaConta.Saldo);
                    comando.Parameters.AddWithValue("@LIMITE", novaConta.Limite);
                    comando.Parameters.AddWithValue("@DATA_ABERTURA", novaConta.DataAbertura);
                    comando.Parameters.AddWithValue("@CESTA", novaConta.CestaServico);
                    comando.Parameters.AddWithValue("@CPF_CLIENTE", novaConta.Cliente.CpfCliente);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Conta> BuscarTodas()
        {
            var listaConta = new List<Conta>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT CC.NUMERO
                                         ,CC.DIGITO
                                         ,CC.AGENCIA
                                         ,CC.TIPO_CONTA
                                         ,CC.SALDO
                                         ,CC.LIMITE
                                         ,CC.DATA_ABERTURA
                                         ,CC.CESTA
                                         ,CC.CPF_CLIENTE
                                         ,C.NOME
                                         ,C.DATA_NASCIMENTO
                                    FROM CONTA CC
                                    INNER JOIN CLIENTE C 
                                    ON C.CPF = CC.CPF_CLIENTE";

                    comando.CommandText = sql;

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var contaBuscada = new Conta
                        {
                            Numero = long.Parse(leitor["NUMERO"].ToString()),
                            Digito = Int32.Parse(leitor["DIGITO"].ToString()),
                            Agencia = leitor["AGENCIA"].ToString(),
                            TipoConta = (TipoConta)Convert.ToInt16(leitor["TIPO_CONTA"].ToString()),
                            CestaServico = (CestaServico)Convert.ToInt16(leitor["CESTA"].ToString()),
                            DataAbertura = Convert.ToDateTime(leitor["DATA_ABERTURA"].ToString()),
                            Limite = double.Parse(leitor["LIMITE"].ToString()),
                            Saldo = double.Parse(leitor["LIMITE"].ToString()),
                            Cliente = new Cliente
                            {
                                CpfCliente = long.Parse(leitor["CPF_CLIENTE"].ToString()),
                                Nome = leitor["NOME"].ToString(),
                                DataNascimento = Convert.ToDateTime(leitor["DATA_NASCIMENTO"].ToString())
                            }
                        };

                        listaConta.Add(contaBuscada);
                    }
                }
            }

            return listaConta;
        }

        public List<Conta> BuscarPorCliente(Cliente cliente)
        {

            var listaConta = new List<Conta>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {

                    comando.Connection = conexao;

                    string sql = @"SELECT CC.NUMERO
                                         ,CC.DIGITO
                                         ,CC.AGENCIA
                                         ,CC.TIPO_CONTA
                                         ,CC.SALDO
                                         ,CC.LIMITE
                                         ,CC.DATA_ABERTURA
                                         ,CC.CESTA
                                         ,CC.CPF_CLIENTE
                                         ,C.NOME
                                         ,C.DATA_NASCIMENTO
                                    FROM CONTA CC
                                    INNER JOIN CLIENTE C 
                                    ON C.CPF = CC.CPF_CLIENTE
                                WHERE CC.CPF_CLIENTE = @CPF_BUSCA";

                    comando.Parameters.AddWithValue("@CPF_BUSCA", cliente.CpfCliente);

                    comando.CommandText = sql;

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var contaBuscada = new Conta
                        {
                            Numero = long.Parse(leitor["NUMERO"].ToString()),
                            Digito = Int32.Parse(leitor["DIGITO"].ToString()),
                            Agencia = leitor["AGENCIA"].ToString(),
                            TipoConta = (TipoConta)Convert.ToInt16(leitor["TIPO_CONTA"].ToString()),
                            CestaServico = (CestaServico)Convert.ToInt16(leitor["CESTA"].ToString()),
                            DataAbertura = Convert.ToDateTime(leitor["DATA_ABERTURA"].ToString()),
                            Limite = double.Parse(leitor["LIMITE"].ToString()),
                            Saldo = double.Parse(leitor["LIMITE"].ToString()),
                            Cliente = new Cliente
                            {
                                CpfCliente = long.Parse(leitor["CPF_CLIENTE"].ToString()),
                                Nome = leitor["NOME"].ToString(),
                                DataNascimento = Convert.ToDateTime(leitor["DATA_NASCIMENTO"].ToString())
                            }
                        };

                        listaConta.Add(contaBuscada);
                    }
                }
            }

            return listaConta;

        }

        public Conta BuscarPorNumero(long numeroConta)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT CC.NUMERO
                                         ,CC.DIGITO
                                         ,CC.AGENCIA
                                         ,CC.TIPO_CONTA
                                         ,CC.SALDO
                                         ,CC.LIMITE
                                         ,CC.DATA_ABERTURA
                                         ,CC.CESTA
                                         ,CC.CPF_CLIENTE
                                         ,C.NOME
                                         ,C.DATA_NASCIMENTO
                                    FROM CONTA CC
                                    INNER JOIN CLIENTE C 
                                    ON C.CPF = CC.CPF_CLIENTE
                                    WHERE CC.NUMERO = @NUMERO_CONTA";

                    comando.Parameters.AddWithValue("@NUMERO_CONTA", numeroConta);

                    comando.CommandText = sql;

                    var leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        var contaBuscada = new Conta
                        {
                            Numero = long.Parse(leitor["NUMERO"].ToString()),
                            Digito = Int32.Parse(leitor["DIGITO"].ToString()),
                            Agencia = leitor["AGENCIA"].ToString(),
                            TipoConta = (TipoConta)Convert.ToInt16(leitor["TIPO_CONTA"].ToString()),
                            CestaServico = (CestaServico)Convert.ToInt16(leitor["CESTA"].ToString()),
                            DataAbertura = Convert.ToDateTime(leitor["DATA_ABERTURA"].ToString()),
                            Saldo = double.Parse(leitor["SALDO"].ToString()),
                            Limite = double.Parse(leitor["LIMITE"].ToString()),
                            Cliente = new Cliente
                            {
                                CpfCliente = long.Parse(leitor["CPF_CLIENTE"].ToString()),
                                Nome = leitor["NOME"].ToString(),
                                DataNascimento = Convert.ToDateTime(leitor["DATA_NASCIMENTO"].ToString())
                            }
                        };

                        return contaBuscada;
                    }
                }
            }

            return null;
        }

    }
}
