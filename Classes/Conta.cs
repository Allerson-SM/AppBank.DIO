using System.Globalization;
using App.Bank.Enum;

namespace App.Bank.Classes
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                System.Console.WriteLine("Saldo insuficiente");
                return false;
            }
            else
            {
                this.Saldo -= valorSaque;

                System.Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");

                return true;
            }
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            System.Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Nome}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia) != false)
            {
                contaDestino.Depositar(valorTransferencia);
            }
            else
            {
                System.Console.WriteLine("Não é possível transferir");
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo da conta: " + this.TipoConta + "\n";
            retorno += "Nome: " + this.Nome + "\n";
            retorno += "Saldo: " + this.Saldo.ToString("C", CultureInfo.CurrentCulture) + "\n";
            retorno += "Crédito: " + this.Credito.ToString("C", CultureInfo.CurrentCulture);
            return retorno;
        }

        public string retornaNome()
        {
            return this.Nome;
        }
    }
}