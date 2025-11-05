using System;

namespace Shared.Domain.Entities;

public class Pessoa
{
    public Pessoa(Guid id, string nome, DateTime dataNascimento)
    {
        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        Nome = nome;
        DataNascimento = dataNascimento;
    }

    public Guid Id { get; }
    public string Nome { get; }
    public DateTime DataNascimento { get; }

    public int CalcularIdade(DateTime referenceDate)
    {
        var idade = referenceDate.Year - DataNascimento.Year;
        if (referenceDate < DataNascimento.AddYears(idade))
        {
            idade--;
        }

        return idade;
    }
}
