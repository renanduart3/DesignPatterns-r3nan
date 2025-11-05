namespace Strategy
{
    public class ICMS : Imposto
    {
        public string Nome { get; set; }
        public ICMS()
        {   
            this.Nome = "ICMS";
        }
        public double CalculaImposto(Orcamento orcamento)
        {
            return orcamento.Valor * 0.25;
        }
    }
}