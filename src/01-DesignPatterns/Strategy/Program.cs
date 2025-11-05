using System;
using Strategy.Planos;
using Strategy.Planos.Interface;

namespace Strategy
{
    class Program
    {
        static void RealizarOrcamento()
        {
            // criacao do orcamento
            Orcamento o1 = new Orcamento(800.00);

            // // criacao dos impostos
            Imposto icms = new ICMS();
            Imposto cofins = new CONFIS();

            // criacao da calculadora
            Calculadora calculo = new Calculadora();

            //calcular os impostos
            calculo.CalcularImposto(o1,icms);
            calculo.CalcularImposto(o1,cofins);
        }
        static void RealizarPlano()
        {
            Pagamento pgto = new Pagamento() { Valor = 500.50 };

            Plano p1 = new IlimitadoInfinity();
            Plano p2 = new BonusMensal();
            Plano p3 = new TotalMais200();

            CalculadoraPlanos c1 = new CalculadoraPlanos();
            c1.CalcularPlano(pgto, p1);
            c1.RetornaListaParcelas(pgto, p1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("---ORCAMENTO----");
            RealizarOrcamento();
            Console.WriteLine("---PLANOS----");
            RealizarPlano();

        }
    }
}
