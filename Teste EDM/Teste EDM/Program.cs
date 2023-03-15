using System;

namespace Teste_EDM
{
    class Program
    {
        static void Main(string[] args)
        {
            var caixa = new Caixa();
            int contador = 0;

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("------------------------Caixa Eletrônico------------------------");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Primeiro passo:");
            Console.WriteLine("Carregar com notas o Caixa Eletrônico.");

            while (contador < caixa.notasValores.Length)
            {
                Console.WriteLine($"Quantas notas do tipo R${caixa.notasValores[contador].ToString("N2")} deseja carregar? Ex: 0,1,2...");
                var valorDigitado = Console.ReadLine();

                if (Validar(valorDigitado))
                {
                    caixa.CadastrarNota(caixa.notasValores[contador], int.Parse(valorDigitado));
                    contador++;
                }              
            }

            Console.WriteLine($"Quanto deseja sacar? Ex: 10, 50, 250");

            var valorSaque = Console.ReadLine();

            if (Validar(valorSaque))
            {
                var retorno = caixa.SacarDinheiro(int.Parse(valorSaque));
                Console.WriteLine(retorno);
            }

            Console.WriteLine("Fim.");
            Console.ReadLine();
        }

        private static bool Validar(string valor)
        {
            if (ValidaValorNotaEUmNumero(valor))
            {
                var valorNumero = int.Parse(valor);

                if (ValidaValorNotaEMaiorQueZero(valorNumero))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool ValidaValorNotaEUmNumero(string valor)
        {
            if (int.TryParse(valor, out _))
                return true;

            Console.WriteLine("A quantidade deve ser um valor inteiro. Ex: 0,1,2...");
            return false;
        }

        private static bool ValidaValorNotaEMaiorQueZero(int valor)
        {
            if (valor >= 0)
                return true;
                
            Console.WriteLine("A quantidade não pode ser menor que zero");
            return false;
        }
    }
}
