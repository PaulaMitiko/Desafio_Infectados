using System;
using System.Threading;

namespace DesafioInfectados
{
    public static class Parametros
    {
        public static char saudavel = '*';
        public static char infectado = '@';
        public static int tempoSegundos;

        private static string Estados()
        {
            Console.WriteLine("Quantos estados deseja monitorar?");
            return Console.ReadLine();
        }
        private static string Pessoas() 
        {
            Console.WriteLine("Qual a amostragem desejada?");
            return Console.ReadLine();
        }
        private static void Erro() 
        {
            Console.WriteLine("Digite um número inteiro.");
            Thread.Sleep(1000);
        }
        private static bool IsInt(this string valor) 
        {
            return int.TryParse(valor, out _);
        }
        private static int InformouNumPessoas() 
        {
            string qtdePessoas = Pessoas();
            int numPessoas;
            if (!qtdePessoas.IsInt())
            {
                Erro();
                numPessoas = InformouNumPessoas();
            }
            else numPessoas = Convert.ToInt32(qtdePessoas);
            return numPessoas;
        }
        public static (int, int) InformouNumeros() 
        {
            string qtdeEstados = Estados();
            int numEstados = 0;
            int numPessoas;
            if (!qtdeEstados.IsInt())
            {
                Erro();
                (numEstados, numPessoas) = InformouNumeros();
            }
            else numEstados = Convert.ToInt32(qtdeEstados);
            if (numEstados > 27) 
            {
                Console.WriteLine("No Brasil temos apenas 27 estados.");
                Thread.Sleep(1000);
                (numEstados, numPessoas) = InformouNumeros();
            }
            numPessoas = InformouNumPessoas();
            return (numEstados, numPessoas);
        }
    }
}
