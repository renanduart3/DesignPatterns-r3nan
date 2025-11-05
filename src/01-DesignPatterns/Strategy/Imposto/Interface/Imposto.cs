namespace Strategy
{
    public interface Imposto
    {
        public string Nome { get; set; }

         double CalculaImposto(Orcamento orcamento);
    }
}