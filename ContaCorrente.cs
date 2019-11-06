using System;

namespace ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        public int TotalSaquesNaoPermitido { get; private set; }
        public int TotalTransferenciasNaoPermitido { get; private set; }
        public static int TaxaOperacao { get; private set; }

        public static int TotalDeContasCriadas { get; private set; }


        private readonly int _agencia;

        private readonly int _numero;

        public int Agencia { get { return _agencia; } }
        public int Numero { get { return _numero; } }

        private double _saldo = 100;

        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }


        public ContaCorrente(int agencia, int numero)
        {
            if (agencia == 0)
            {
                throw new ArgumentException("Argumento inválido, agência tem que ser maior que 0.", nameof(agencia));
            }
            if (numero == 0)
            {
                throw new ArgumentException("Argumento inválido, número tem que ser maior que 0.", nameof(numero));
            }

            _agencia = agencia;
            _numero = numero;

            TotalDeContasCriadas++;

            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor de saque menor que 0, operação impossível.");
            }
            if (_saldo < valor)
            {
                TotalSaquesNaoPermitido++;
                throw new SaldoInsuficienteExcepetion(_saldo, valor);
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }


        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor de saque menor que 0, operação impossível.");
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteExcepetion ex)
            {
                TotalTransferenciasNaoPermitido++;
                throw new OperacaoFinanceiraException("Operação não relizada.", ex); 
            }

            contaDestino.Depositar(valor);
        }
    }
}
