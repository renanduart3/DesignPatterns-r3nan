using System;
using System.Collections.Generic;
using Strategy.Planos.Interface;

namespace Strategy
{
    public class CalculadoraPlanos
    {
        public void CalcularPlano(Pagamento pagamento, Plano plano)
        {
            double valorPlano = plano.CalculoValorPlano(pagamento);

            Console.WriteLine($"Valor do plano {plano.Nome}> {valorPlano}");

        }

        public void RetornaListaParcelas(Pagamento pagamento, Plano plano)
        {
            Random r = new Random();
            int numParcelas = r.Next(plano.ParcelasMax);

            Console.WriteLine($"{numParcelas} parcelas: \n");
            for (int i = 1; i <= numParcelas; i++)
            {
                double parcela = pagamento.Valor / numParcelas;
                System.Console.WriteLine($"{i} > R$ {parcela.ToString("0.##")}");
            }

        }
    }
}