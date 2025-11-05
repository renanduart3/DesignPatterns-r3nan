using System;
using System.Collections.Generic;
using Strategy.Planos.Interface;

namespace Strategy.Planos
{
    public class IlimitadoInfinity : Plano
    {
        public string Nome { get; }
        public int ParcelasMax { get; set; }
        public IlimitadoInfinity()
        {
            this.Nome = "Total + 200";
            this.ParcelasMax = 6;
        }
        public double CalculoValorPlano(Pagamento pagamento)
        {
            return pagamento.Valor + 1.99;
        }
    }
}