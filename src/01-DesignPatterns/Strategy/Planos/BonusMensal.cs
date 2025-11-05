using System;
using System.Collections.Generic;
using Strategy.Planos.Interface;

namespace Strategy.Planos
{
    public class BonusMensal : Plano
    {
        public string Nome { get; }
        public int ParcelasMax { get; set; }
        public BonusMensal()
        {
            this.Nome = "Total + 200";
            this.ParcelasMax = 15;
        }
        public double CalculoValorPlano(Pagamento pagamento)
        {
            return pagamento.Valor + 15.99;
        }
    }
}