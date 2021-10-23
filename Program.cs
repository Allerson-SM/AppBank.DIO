using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using App.Bank.Classes;
using App.Bank.Enum;

namespace App.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            Opcoes();
        }

        public static string EscolhaUsuario()
        {
            System.Console.WriteLine("----------App Bank----------");
            System.Console.WriteLine("Selecione uma das opções abaixo:");
            System.Console.WriteLine();
            System.Console.WriteLine("1 - Listar contas");
            System.Console.WriteLine("2 - Cadastrar nova conta");
            System.Console.WriteLine("3 - Transferir");
            System.Console.WriteLine("4 - Sacar");
            System.Console.WriteLine("5 - Depositar");
            System.Console.WriteLine("C - Limpar tela");
            System.Console.WriteLine("X - Sair");
            System.Console.WriteLine();

            string escolhaUsuario = Console.ReadLine().ToUpper();
            return escolhaUsuario;
        }

        public static void Opcoes()
        {
            string escolhaUsuario = EscolhaUsuario();

            while (escolhaUsuario != "X")
            {
                switch (escolhaUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        CadastrarConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                escolhaUsuario = EscolhaUsuario();
            }
            System.Console.WriteLine("Obrigado por utilizar os nossos serviços!");
        }

        private static void Depositar()
        {
            Console.Clear();
            System.Console.WriteLine("----------Depositar----------");

            if (listaContas.Any())
            {
                System.Console.WriteLine("Contas registradas atualmente");
                for (int i = 0; i <= listaContas.Count() - 1; i++)
                {
                    System.Console.WriteLine($"{i} - {listaContas[i].retornaNome()}");
                }
                System.Console.WriteLine();

                System.Console.WriteLine("Informe o valor a ser depositado: ");
                double valorDeposito = Convert.ToDouble(Console.ReadLine());

                System.Console.WriteLine("Informe o número da conta: ");
                int numeroConta = Convert.ToInt32(Console.ReadLine());

                listaContas[numeroConta].Depositar(valorDeposito);

                System.Console.WriteLine($"Valor {valorDeposito.ToString("C", CultureInfo.CurrentCulture)} depositado com sucesso!");

                System.Console.WriteLine();
                System.Console.WriteLine("Pressione qualquer tecla para sair");
                Console.ReadLine();
            }
            else
            {
                System.Console.WriteLine("Não há contas cadastradas!");
            }
        }

        private static void Transferir()
        {
            Console.Clear();
            System.Console.WriteLine("----------Transferir----------");
            System.Console.WriteLine();

            if (listaContas.Any())
            {
                System.Console.WriteLine("Contas registradas atualmente");
                for (int i = 0; i <= listaContas.Count() - 1; i++)
                {
                    System.Console.WriteLine($"{i} - {listaContas[i].retornaNome()}");
                }
                System.Console.WriteLine();

                System.Console.WriteLine("Informe o valor a ser transferido: ");
                double valorTransferencia = Convert.ToDouble(Console.ReadLine());

                System.Console.WriteLine("Informe o número da conta de origem: ");
                int numeroContaOrigem = Convert.ToInt32(Console.ReadLine());

                System.Console.WriteLine("Informe o número da conta de destino: ");
                int numeroContaDestino = Convert.ToInt32(Console.ReadLine());

                listaContas[numeroContaOrigem].Transferir(valorTransferencia, listaContas[numeroContaDestino]);
            }
            else
            {
                System.Console.WriteLine("Não há contas cadastradas!");
            }
        }

        private static void Sacar()
        {
            Console.Clear();
            System.Console.WriteLine("----------Sacar----------");

            if (listaContas.Any())
            {
                System.Console.WriteLine("Contas atualmente cadastradas:");


                for (int i = 0; i <= listaContas.Count() - 1; i++)
                {
                    System.Console.WriteLine($"{i} - {listaContas[i].retornaNome()}");
                }

                System.Console.WriteLine("Digite o número da conta: ");
                int numeroConta = Convert.ToInt32(Console.ReadLine());


                if (numeroConta > listaContas.Count() - 1)
                {
                    System.Console.WriteLine("A conta informada não existe!");
                    return;
                }
                else
                {
                    System.Console.WriteLine("Digite o valor a ser sacado: ");
                    double valorSaque = Convert.ToDouble(Console.ReadLine());

                    listaContas[numeroConta].Sacar(valorSaque);
                    System.Console.WriteLine($"Valor de {valorSaque.ToString("C", CultureInfo.CurrentCulture)} sacado com sucesso!");
                    System.Console.WriteLine("Pressione qualquer botão para sair");
                    Console.ReadLine();
                }

            }
            else
            {
                System.Console.WriteLine("Não há contas cadastradas!");
                System.Console.WriteLine("Pressione qualquer botão para sair");
                Console.ReadLine();
            }

        }

        private static void ListarContas()
        {
            Console.Clear();
            System.Console.WriteLine("----------Listar contas----------");

            if (listaContas.Any())
            {
                for (int i = 0; i <= listaContas.Count - 1; i++)
                {
                    System.Console.WriteLine($"Número da conta - {i}");
                    System.Console.WriteLine(listaContas[i].ToString());
                    System.Console.WriteLine();
                    System.Console.WriteLine("Pressione qualquer botão para sair");
                    Console.ReadLine();
                }
            }
            else
            {
                System.Console.WriteLine("Nenhuma conta cadastrada!");
                System.Console.WriteLine("Pressione qualquer botão para sair");
                Console.ReadLine();
            }
        }

        private static void CadastrarConta()
        {
            Console.Clear();
            System.Console.WriteLine("---------Cadastrar nova conta---------");

            System.Console.WriteLine("Digite 1 para Pessoa Física ou 2 para Pessoa Jurídica:");
            int entradaTipoConta = Convert.ToInt32(Console.ReadLine());

            System.Console.WriteLine("Digite o nome do titular:");
            string entradaNome = Console.ReadLine();

            System.Console.WriteLine("Digite o saldo inicial:");
            double saldoEntrada = Convert.ToDouble(Console.ReadLine());

            System.Console.WriteLine("Digite o crédito inicial:");
            double creditoEntrada = Convert.ToDouble(Console.ReadLine());

            Conta novaConta = new Conta((TipoConta)entradaTipoConta,
                                        saldoEntrada,
                                        creditoEntrada,
                                        entradaNome);
            listaContas.Add(novaConta);

            System.Console.WriteLine();
            System.Console.WriteLine("Conta cadastrada com sucesso!");
            System.Console.WriteLine();
            System.Console.WriteLine("Pressione qualquer tecla para sair");
            Console.ReadLine();
        }
    }
}
