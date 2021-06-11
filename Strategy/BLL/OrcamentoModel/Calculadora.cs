using System;

namespace Strategy
{
    public class Calculadora
    {
        public void CalcularImposto(Orcamento orcamento, Imposto imposto)
        {
            double valorImposto = imposto.CalculaImposto(orcamento);
            Console.WriteLine($"Valor do imposto {imposto.Nome}> {valorImposto}");
        }
    }
}