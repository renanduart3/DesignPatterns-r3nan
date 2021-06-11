using System;
using System.Collections.Generic;
using Strategy.Planos.Interface;

namespace Strategy.Planos
{
    public class TotalMais200 : Plano
    {
        public string Nome { get; }
        public int ParcelasMax { get; set; }
        public TotalMais200()
        {
            this.Nome = "Total + 200";
            this.ParcelasMax = 12;
        }

        public double CalculoValorPlano(Pagamento pagamento)
        {
            return pagamento.Valor + 5.99;
        }

    }
}