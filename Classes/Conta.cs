using System;
using DIO.Bank.Enum;

namespace DIO.Bank
{
    public class Conta
    {
        private int Id{get;set;}
        private TipoConta TipoConta{get;set;}
        private double Saldo {get;set;}
        private double Credito {get;set;}
        private string Nome {get;set;}

        public Conta(int id, TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.Id = id;
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < this.Credito *-1)
            {
                Console.WriteLine("Saldo insulficiente");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
            return true;
        }

        public void Depositar(double valorDepositado)
        {
            this.Saldo += valorDepositado;

            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += $"Id: {this.Id} |";
            retorno += $"Tipo Conta: {this.TipoConta} |";
            retorno += $"Nome: {this.Nome} |";
            retorno += $"Saldo: {this.Saldo} |";
            retorno += $"Crédito: {this.Credito} |";

            return retorno;
        }
    }
    
}