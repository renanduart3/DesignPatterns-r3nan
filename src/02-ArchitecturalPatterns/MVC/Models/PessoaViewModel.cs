using System;
using Shared.Domain.Entities;

namespace ArchitecturalPatterns.MVC.Models;

public record PessoaViewModel(Guid Id, string Nome, int Idade)
{
    public static PessoaViewModel FromEntity(Pessoa pessoa, DateTime referenceDate) =>
        new(pessoa.Id, pessoa.Nome, pessoa.CalcularIdade(referenceDate));
}
