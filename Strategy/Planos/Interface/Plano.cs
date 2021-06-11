using System.Collections.Generic;

namespace Strategy.Planos.Interface
{
    public interface Plano
    {
        string Nome { get; }
        int ParcelasMax { get; }

        double CalculoValorPlano(Pagamento pagamento);

    }
}