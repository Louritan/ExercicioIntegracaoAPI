using System;
using BancoSolution.Domain;
using BancoSolution.Infra.Data;

namespace BancoSolution.ConsoleApp
{
    class Program
    {
        static IClienteRepository _clienteRepository = new ClienteRepository();
        static IContaRepository _contaRepository = new ContaRepository();
        static IContratoRepository _contratoRepository = new ContratoRepository();

        static string _opcaoCliente = "";
        static string _opcaoConta = "";
        static string _opcaoContrato = "";
        static string _opcaoPrincipal = "";

        static void Main(string[] args)
        {
            EscolherUmaOpcaoPrincipal();
        }

        public static void EscolherUmaOpcaoPrincipal()
        {
            Console.Clear();
            Console.WriteLine(" --         MENU PRINCIPAL         -- ");
            Console.WriteLine(" Escolha umas das opções abaixo:");
            Console.WriteLine(" 1 - Gerenciar Cliente");
            Console.WriteLine(" 2 - Gerenciar Contas");
            Console.WriteLine(" 3 - Gerenciar Contratos");
            Console.WriteLine(" 4 - Sair");
            Console.Write("=> ");
            _opcaoPrincipal = Console.ReadLine();

            switch (_opcaoPrincipal)
            {
                case "1":
                    Console.Clear();
                    GerenciarCliente();
                    break;
                case "2":
                    Console.Clear();
                    GerenciarConta();
                    break;
                case "3":
                    Console.Clear();
                    GerenciarContrato();
                    break;
                case "4":
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    break;
            }

        }

        public static void VoltarMenuCliente()
        {
            GerenciarCliente();
        }

        public static void VoltarMenuConta()
        {
            GerenciarConta();
        }

        public static void VoltarMenuContrato()
        {
            GerenciarContrato();
        }


        public static void GerenciarCliente()
        {
            Console.Clear();
            Console.WriteLine(" --         MENU CLIENTE       -- ");
            Console.WriteLine(" Escolha umas das opções abaixo:");
            Console.WriteLine(" 1 - Buscar todos os cliente");
            Console.WriteLine(" 2 - Buscar cliente por CPF");
            Console.WriteLine(" 3 - Voltar ao menu principal");
            Console.Write("=> ");
            _opcaoCliente = Console.ReadLine();

            FuncionalidadesCliente();
        }

        public static void GerenciarConta()
        {
            Console.Clear();
            Console.WriteLine(" --         MENU CONTA       -- ");
            Console.WriteLine(" Escolha umas das opções abaixo:");
            Console.WriteLine(" 1 - Cadastrar uma nova conta");
            Console.WriteLine(" 2 - Buscar todas as contas");
            Console.WriteLine(" 3 - Buscar conta por cliente");
            Console.WriteLine(" 4 - Voltar ao menu principal");
            Console.Write("=> ");
            _opcaoConta = Console.ReadLine();

            FuncionalidadesConta();
        }

        public static void GerenciarContrato()
        {
            Console.Clear();
            Console.WriteLine(" --         MENU CONTRATO       -- ");
            Console.WriteLine(" Escolha umas das opções abaixo:");
            Console.WriteLine(" 1 - Cadastrar um novo contrato");
            Console.WriteLine(" 2 - Buscar contrato por cliente");
            Console.WriteLine(" 3 - Voltar ao menu principal");
            Console.Write("=> ");
            _opcaoContrato = Console.ReadLine();

            FuncionalidadesContrato();
        }

        public static void FuncionalidadesCliente()
        {
            switch (_opcaoCliente)
            {
                case "1":
                    Console.Clear();
                    BuscarTodosClientes();
                    VoltarMenuCliente();
                    break;
                case "2":
                    Console.Clear();
                    BuscarClientePorCpf();
                    VoltarMenuCliente();
                    break;
                case "3":
                    EscolherUmaOpcaoPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    VoltarMenuCliente();
                    break;
            }

        }

        public static void FuncionalidadesConta()
        {
            switch (_opcaoConta)
            {
                case "1":
                    Console.Clear();
                    CadastraConta();
                    VoltarMenuConta();
                    break;
                case "2":
                    Console.Clear();
                    BuscarTodasContas();
                    VoltarMenuConta();
                    break;
                case "3":
                    Console.Clear();
                    BuscarContaPorCliente();
                    VoltarMenuConta();
                    break;
                case "4":
                    EscolherUmaOpcaoPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    VoltarMenuConta();
                    break;
            }

        }

        public static void FuncionalidadesContrato()
        {
            switch (_opcaoContrato)
            {
                case "1":
                    Console.Clear();
                    CadastraContrato();
                    VoltarMenuConta();
                    break;
                case "2":
                    Console.Clear();
                    BuscarContratoPorCliente();
                    VoltarMenuConta();
                    break;
                case "3":
                    EscolherUmaOpcaoPrincipal();
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    Console.ReadKey();
                    VoltarMenuConta();
                    break;
            }

        }
        public static void BuscarTodosClientes()
        {
            Console.WriteLine("--           LISTA CLIENTES         -- \n");

            foreach (var item in _clienteRepository.BuscarTodosClientes())
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------------------------------");
            }

            Console.ReadKey();
        }

        public static void BuscarClientePorCpf()
        {
            Console.WriteLine("--           CLIENTE         -- \n");

            Console.WriteLine("Digite o CPF do cliente que será buscado:");
            var cpfCliente = long.Parse(Console.ReadLine());

            var clienteEncontrado = _clienteRepository.BuscarClientePorCpf(cpfCliente);
            Console.WriteLine("Cliente encontrado:");
            Console.WriteLine("--------------------------------------");
            if (clienteEncontrado.CpfCliente != 0)
            {
                Console.WriteLine(clienteEncontrado);
            }
            Console.ReadKey();
        }

        public static void CadastraConta()
        {


            Conta novaConta = new Conta();
            Console.WriteLine("--                   CADASTRO DE CONTA                -- ");

            Console.WriteLine("Digite o número da conta:");
            novaConta.Numero = long.Parse(Console.ReadLine());

            Console.WriteLine("Digite a agência:");
            novaConta.Agencia = Console.ReadLine();

            Console.WriteLine("Digite o digito:");
            novaConta.Digito = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta:");
            novaConta.Numero = long.Parse(Console.ReadLine());

            Console.WriteLine("Digite o limite:");
            novaConta.Limite = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o tipo de conta: 001 - 013 - 1288");
            novaConta.TipoConta = (TipoConta)Convert.ToInt16(Console.ReadLine());

            if (novaConta.TipoConta == TipoConta.Corrente)
            {
                Console.WriteLine("Digite a cesta serviço: Ouro -> 1 - Prata -> 2 - Platina -> 3");
                novaConta.CestaServico = (CestaServico)Convert.ToInt16(Console.ReadLine());
            }
            else
            {
                novaConta.CestaServico = CestaServico.Nenhuma;
            }

            Console.WriteLine("Digite o CPF do cliente:");
            var cpfCliente = long.Parse(Console.ReadLine());

            try
            {
                novaConta.Cliente = _clienteRepository.BuscarClientePorCpf(cpfCliente);

                _contaRepository.CadastraNovaConta(novaConta);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                VoltarMenuConta();
            }

        }

        public static void BuscarTodasContas()
        {

            Console.WriteLine("--           LISTA CONTAS         -- \n");

            foreach (var item in _contaRepository.BuscarTodasContas())
            {
                Console.WriteLine(item);
                Console.WriteLine("--------------------------------------");
            }

            Console.ReadKey();
        }

        public static void BuscarContaPorCliente()
        {

            Console.WriteLine("--           CONTA         -- \n");

            Console.WriteLine("Digite o CPF do cliente da conta:");
            var cpfCliente = long.Parse(Console.ReadLine());

            try
            {
                var contasEncontradas = _contaRepository.BuscarContasPorCliente(cpfCliente);
                Console.WriteLine("Conta encontrada:");
                Console.WriteLine("--------------------------------------");
                foreach (var item in contasEncontradas)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                VoltarMenuConta();
            }

        }

        public static void CadastraContrato()
        {

            Contrato novoContrato = new Contrato();
            Console.WriteLine("--                   CADASTRO DE CONTRATO                -- ");

            Console.WriteLine("Digite o número do contrato:");
            novoContrato.Numero = long.Parse(Console.ReadLine());

            Console.WriteLine("O tipo de contrato: Consignado -> 1 - CDC -> 2 - Habtacional -> 3");
            novoContrato.TipoContrato = (TipoContrato)int.Parse(Console.ReadLine());

            Console.WriteLine("Quantidade de parcelas:");
            novoContrato.QunatidadeParcelas = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor total:");
            novoContrato.ValorTotal = double.Parse(Console.ReadLine());


            Console.WriteLine("Digite o CPF do cliente:");
            var cpfCliente = long.Parse(Console.ReadLine());

            try
            {
                novoContrato.Cliente = _clienteRepository.BuscarClientePorCpf(cpfCliente);

                _contratoRepository.CadastraNovoContrato(novoContrato);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                VoltarMenuContrato();
            }

        }

        public static void BuscarContratoPorCliente()
        {

            Console.WriteLine("--           CONTRATO         -- \n");

            Console.WriteLine("Digite o CPF do cliente da conta:");
            var cpfCliente = long.Parse(Console.ReadLine());

            try
            {
                var contratoEncontrados = _contratoRepository.BuscarContratosPorCliente(cpfCliente);

                Console.WriteLine("Contrato encontrado:");
                Console.WriteLine("--------------------------------------");
                foreach (var item in contratoEncontrados)
                {
                    Console.WriteLine(item);
                }
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                VoltarMenuConta();
            }

        }
    }
}
