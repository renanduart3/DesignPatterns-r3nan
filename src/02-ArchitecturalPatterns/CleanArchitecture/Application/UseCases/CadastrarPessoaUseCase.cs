using System;
using System.Threading;
using System.Threading.Tasks;
using Shared.Domain.Entities;
using Shared.Domain.Repositories;

namespace ArchitecturalPatterns.CleanArchitecture.Application.UseCases;

public class CadastrarPessoaUseCase
{
    private readonly IPessoaRepository _repository;

    public CadastrarPessoaUseCase(IPessoaRepository repository)
    {
        _repository = repository;
    }

    public Task<Pessoa> ExecuteAsync(string nome, DateTime dataNascimento, CancellationToken cancellationToken = default)
    {
        var pessoa = new Pessoa(Guid.NewGuid(), nome, dataNascimento);
        return _repository.CadastrarAsync(pessoa, cancellationToken);
    }
}
