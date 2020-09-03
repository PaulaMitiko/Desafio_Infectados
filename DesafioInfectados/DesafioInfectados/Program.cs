using System;
using System.Collections.Generic;
using System.Threading;

namespace DesafioInfectados
{
    class Program
    {
        static void Main()
        {
            Monitoramento amostra = new Monitoramento();
            (amostra.Estados, amostra.Pessoas) = Parametros.InformouNumeros();

            Console.Clear();
            for (int i = 0; i < amostra.Estados; i++) 
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Estado {0} => ", i+1);
                for (int j = 0; j < amostra.Pessoas; j++) 
                {
                    Console.Write("{0} ",Parametros.saudavel);
                }
                Console.WriteLine();
            }
            Thread.Sleep(1000);

            HashSet<(int, int)> listaInfectados = new HashSet<(int, int)>();
         
            do
            {
                Console.Clear();

                Calculo infectado = new Calculo();
                var auxInfectado = infectado.Infectado(amostra);
                listaInfectados.Add(auxInfectado);
                
                for (int i = 0; i < amostra.Estados; i++)
                { 
                    Console.ForegroundColor = ConsoleColor.Green;
                    
                    if (i == auxInfectado.Item1) Console.ForegroundColor = ConsoleColor.Red;
                    
                    Console.Write("Estado {0} => ", i+1);
                    
                    for (int j = 0; j < amostra.Pessoas; j++) 
                    {
                        bool estaSaudavel = true;
                        foreach (var inf in listaInfectados)
                        {
                            if (inf.Item1 == i && inf.Item2 == j)
                            {
                                Console.Write("{0} ", Parametros.infectado);
                                estaSaudavel = false;
                            }
                        }
                        if (estaSaudavel) Console.Write("{0} ", Parametros.saudavel);
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(1000);
                Parametros.tempoSegundos++;
            } while (Parametros.tempoSegundos < 60);
            
            Console.ReadKey();
        }
    }
}
