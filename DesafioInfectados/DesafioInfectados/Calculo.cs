using System;

namespace DesafioInfectados
{
    public class Calculo : Monitoramento
    {
        public (int, int) Infectado(Monitoramento amostra) 
        {
            Random rdm = new Random();
            int pessoaInfectada = rdm.Next(1,amostra.Estados * amostra.Pessoas);

            int linha = ((pessoaInfectada + amostra.Pessoas - 1) / amostra.Pessoas) - 1; 
            int coluna = (pessoaInfectada - 1) %  amostra.Pessoas;

            return (linha, coluna);
        }
    }
}
