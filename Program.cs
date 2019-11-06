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
                ContaCorrente conta = new ContaCorrente(4654, 4568798);
                ContaCorrente conta2 = new ContaCorrente(465454, 456845);
                Console.WriteLine("Contas criadas com sucesso");
                conta.Transferir(1000, conta2);
                //Console.WriteLine("Transferência feita com sucesso!");
                //conta.Sacar(1000);
            }
            catch (SaldoInsuficienteExcepetion ex)
            {
                Console.WriteLine(ex.Saldo);
                Console.WriteLine(ex.ValorSaque);
                Console.WriteLine(ex.StackTrace);

                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.ParamName);
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
