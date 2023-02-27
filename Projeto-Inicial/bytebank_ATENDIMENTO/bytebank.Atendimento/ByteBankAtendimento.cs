using bytebank.Modelos.Conta;
using bytebank_ATENDIMENTO.bytebank.Exceptions;
using Newtonsoft.Json;

namespace bytebank_ATENDIMENTO.bytebank.Atendimento
{
    internal class ByteBankAtendimento
    {
        private List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
        {
            new ContaCorrente(95, "123456-X"){Saldo = 100},
            new ContaCorrente(96, "123456-Y"){Saldo = 200},
            new ContaCorrente(97, "123456-Z"){Saldo = 300},
        };

        public void AtendimentoCliente()
        {
            try
            {
                char opcao = '0';

                while (opcao != '7')
                {
                    Console.Clear();

                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("---              Atendimento              ---");
                    Console.WriteLine("---  1 - Cadastrar Conta                  ---");
                    Console.WriteLine("---  2 - Listar Contas                    ---");
                    Console.WriteLine("---  3 - Remover Contas                   ---");
                    Console.WriteLine("---  4 - Ordenar Contas                   ---");
                    Console.WriteLine("---  5 - Pesquisar Conta                  ---");
                    Console.WriteLine("---  6 - Exportar Contas                  ---");
                    Console.WriteLine("---  7 - Sair do Sistema                  ---");
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("\n\n");

                    Console.WriteLine("Digite a opção desejada:");

                    try
                    {
                        opcao = Console.ReadLine()[0];
                    }
                    catch (Exception e)
                    {
                        throw new ByteBankExceptions(e.Message);
                    }


                    switch (opcao)
                    {
                        case '1':
                            CadastrarConta();
                            break;
                        case '2':
                            ListarConta();
                            break;
                        case '3':
                            RemoverConta();
                            break;
                        case '4':
                            OrdenarContas();
                            break;
                        case '5':
                            PesquisarConta();
                            break;
                        case '6':
                            ExportarContas();
                            break;
                        case '7':
                            FecharSistema();
                            break;
                        default:
                            Console.WriteLine("Opção não implementada!");
                            break;
                    }
                }
            }
            catch (ByteBankExceptions e)
            {
                Console.WriteLine("Aconteceu uma exceção: " + e.Message);
            }
        }

        private void FecharSistema()
        {
            Console.WriteLine("\n... Encerrando a aplicação ...");
            Console.ReadKey();
        }

        private void PesquisarConta()
        {
            Console.Clear();

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---            PESQUSIAR CONTA            ---");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("\n");

            Console.WriteLine("Digite o número da conta: ");
            string numeroConta = Console.ReadLine();

            var buscaConta = _listaDeContas.FirstOrDefault(w => w.Conta == numeroConta);

            if (buscaConta != null)
            {
                Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine("\n---            DADOS DA CONTA            ---\n");
                Console.WriteLine("Número da Conta: " + buscaConta.Conta);
                Console.WriteLine("Saldo da Conta: " + buscaConta.Saldo);
                Console.WriteLine("Titular da Conta: " + buscaConta.Titular.Nome);
                Console.WriteLine("CPF do Titular: " + buscaConta.Titular.Cpf);
                Console.WriteLine("Profissão do Titular: " + buscaConta.Titular.Profissao);
                Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            }
            else
            {
                Console.WriteLine("\n... Nenhuma conta encontrada! ...");
            }
            Console.ReadKey();
        }

        private void OrdenarContas()
        {
            _listaDeContas.Sort();

            Console.WriteLine("\n Lista de contas ordenada com sucesso!");
            Console.ReadKey();
        }

        private void RemoverConta()
        {
            Console.Clear();

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---             REMOVER CONTA             ---");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("\n");

            Console.WriteLine("Digite o número da conta: ");
            string numeroConta = Console.ReadLine();

            var buscaConta = _listaDeContas.FirstOrDefault(w => w.Conta == numeroConta);

            if (buscaConta != null)
            {
                _listaDeContas.Remove(buscaConta);

                Console.WriteLine("\n... Conta removida com sucesso! ...");
            }
            else
            {
                Console.WriteLine("\n... Nenhuma conta encontrada! ...");
            }
            Console.ReadKey();
        }

        private void ListarConta()
        {
            Console.Clear();

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---            LISTA DE CONTAS            ---");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("\n");

            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("\n ... Não há contas cadastradas! ...");
                Console.ReadKey();
                return;
            }

            foreach (ContaCorrente item in _listaDeContas)
            {
                Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
                Console.WriteLine("\n---            DADOS DA CONTA            ---\n");
                Console.WriteLine("Número da Conta: " + item.Conta);
                Console.WriteLine("Saldo da Conta: " + item.Saldo);
                Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
                Console.WriteLine("CPF do Titular: " + item.Titular.Cpf);
                Console.WriteLine("Profissão do Titular: " + item.Titular.Profissao);
                Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n\n");
            }
            Console.ReadKey();
        }

        private void ExportarContas()
        {
            Console.Clear();

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---            EXPORTAR CONTAS            ---");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("\n");

            if (_listaDeContas.Count <= 0)
            {
                Console.WriteLine("\n ... Não há dadaos para exportação! ...");
                Console.ReadKey();
                return;
            }
            else
            {
                string json = JsonConvert.SerializeObject(_listaDeContas, Formatting.Indented);

                try
                {
                    FileStream fs = new FileStream(@"C:\Repo\contas.json", FileMode.Create);

                    using (StreamWriter streamWriter = new StreamWriter(fs))
                    {
                        streamWriter.WriteLine(json);
                    }
                    Console.WriteLine("\n ... Arquivo salvo com sucesso! ...");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    throw new ByteBankExceptions(e.Message);
                }
            }
        }

        private void CadastrarConta()
        {
            Console.Clear();

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---           CADASTRO DE CONTA           ---");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("\n");
            Console.WriteLine("Informe os dados da conta");
            Console.WriteLine("\n");

            Console.Write("Número da Conta: ");
            string numeroConta = Console.ReadLine();

            Console.Write("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente Conta = new ContaCorrente(numeroAgencia, numeroConta);

            Console.Write("Informa o Saldo Inicial: ");
            Conta.Saldo = double.Parse(Console.ReadLine());

            Console.Write("Informa o Nome do Titular: ");
            Conta.Titular.Nome = Console.ReadLine();

            Console.Write("Informa o CPF do Titular: ");
            Conta.Titular.Cpf = Console.ReadLine();

            Console.Write("Informa a Profissão do Titular: ");
            Conta.Titular.Profissao = Console.ReadLine();

            _listaDeContas.Add(Conta);

            Console.WriteLine("\n... Conta cadastrada com sucesso! ...");
            Console.ReadKey();
        }
    }
}
