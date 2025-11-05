namespace Shared.Domain.ValueObjects;

public record Endereco(
    string Logradouro,
    string Numero,
    string Bairro,
    string Cidade,
    string Estado,
    string Cep)
{
    public override string ToString()
        => $"{Logradouro}, {Numero} - {Bairro}, {Cidade} - {Estado}, {Cep}";
}
