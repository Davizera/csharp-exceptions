using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(123, 456789);
                ContaCorrente conta2 = new ContaCorrente(123, 987654);

                conta.Sacar(10000);

            }
            //catch(ArgumentException)
            //{

            //}
            //catch (SaldoInsuficienteExcepetion)
            //{

            //}
            catch (OperacaoFinanceiraException e)
            {
                Console.Write(e.Message);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write(e.StackTrace);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("Informações da innerException: ");
                Console.WriteLine(e.InnerException);

            }

            Console.WriteLine("Aperte enter para sair da aplicação . . .");
            Console.ReadLine();
        }
    }
}
