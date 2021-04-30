using System;
using System.Collections.Generic;
using DIO.Bank.Enum;

namespace DIO.Bank.Classes
{
    public class App
    {        
        private Opcoes opcaoUsuario;
        static ContaRepositorio repositorio = new ContaRepositorio();

        public App()
        {
            this.opcaoUsuario = Opcoes.Rodando;
            Console.WriteLine("Bem Vindo ao DIO Bank");
        }

        public void IniciarPrograma()
        {
            while (opcaoUsuario != Opcoes.Sair)
            {
                opcaoUsuario = obterOpcaoUsuario();

                switch (opcaoUsuario)
                {
                    case Opcoes.Listar:
                        listarConta();
                        break;
                    case Opcoes.Inserir:                        
                        limparTela();
                        InserirConta();
                        break;
                    case Opcoes.Sacar:
                        listarConta();
                        Sacar();
                        break;
                    case Opcoes.Depositar:
                        listarConta();
                        Depositar();
                        break;
                    case Opcoes.Transferir:
                        listarConta();
                        Transferir();
                        break;                    
                    default:
                        break;
                }

            }

            Console.WriteLine("Obrigado Por Usar o DIO Bank");
        }

        private void listarConta()
        {
            limparTela();

            Console.WriteLine("Listar Contas");

            var lista  = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta Cadastrada.");
                return;
            }

            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }

        public void limparTela()
        {
            Console.Clear();
        }
        
        public static Opcoes obterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(" --- Controle Bancário --- ");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Lista Contas");
            Console.WriteLine("2- Inserir Nova Conta");
            Console.WriteLine("3- Sacar");
            Console.WriteLine("4- Depositar");
            Console.WriteLine("5- Transferir");
            Console.WriteLine("6- Limpar Tela");            
            Console.WriteLine("7- Sair");
            Console.WriteLine();

            int opcaoUsuario = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            return (Opcoes)opcaoUsuario;
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSacar = double.Parse(Console.ReadLine());

            var conta  = repositorio.RetornaPorId(indiceConta);
            conta.Sacar(valorSacar);
            repositorio.Atualiza(indiceConta, conta);
        }

        private static void Depositar()
        {
            Console.WriteLine("Digite o número da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDepositado = double.Parse(Console.ReadLine());

            var conta = repositorio.RetornaPorId(indiceConta);
            conta.Depositar(valorDepositado);
            repositorio.Atualiza(indiceConta, conta);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o número da conta de Origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            var contaOrigem = repositorio.RetornaPorId(indiceContaOrigem);
            var contaDestino = repositorio.RetornaPorId(indiceContaDestino);
            contaOrigem.Transferir(valorTransferencia, contaDestino);

            repositorio.Atualiza(indiceContaDestino, contaDestino);
            repositorio.Atualiza(indiceContaOrigem, contaOrigem);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir uma Nova Conta");            
            repositorio.Insere(preencherConta(repositorio.ProximoId()));
        }

        static Conta preencherConta(int IdConta)
        {
            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Conta Juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do Cliente: ");
            string entradaNome  = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(
                IdConta,
                (TipoConta)entradaTipoConta,
                entradaSaldo,
                entradaCredito,
                entradaNome
            );

            return novaConta;
        }
    }

}