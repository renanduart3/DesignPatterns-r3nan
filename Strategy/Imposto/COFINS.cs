namespace Strategy
{
    public class CONFIS : Imposto
    {
        public string Nome { get; set; }
        public CONFIS()
        {   
            this.Nome = "Cofins";
        }
        public double CalculaImposto(Orcamento orcamento)
        {
            return orcamento.Valor * 0.5;
        }

    }
}