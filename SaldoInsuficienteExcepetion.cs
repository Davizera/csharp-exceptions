using System;
using System.Runtime.Serialization;

namespace ByteBank
{
    [Serializable]
    internal class SaldoInsuficienteExcepetion : OperacaoFinanceiraException
    {
        public double Saldo { get; }
        public double ValorSaque { get; }
        public SaldoInsuficienteExcepetion()
        {
        }

        public SaldoInsuficienteExcepetion(string message) : base(message)
        {
        }

        public SaldoInsuficienteExcepetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        public SaldoInsuficienteExcepetion(double saldo, double valorSaque) : this("Tentativa de saque de R$" + valorSaque + " com saldo de R$" + saldo)
        {
            Saldo = saldo;
            ValorSaque = valorSaque;
        }

    }
}