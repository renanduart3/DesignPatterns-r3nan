using System;
using System.Threading;
using System.Threading.Tasks;
using Shared.Domain.Entities;
using Shared.Domain.Repositories;

namespace ArchitecturalPatterns.CleanArchitecture.Application.UseCases;

public class ObterPessoaPorIdUseCase
{
    private readonly IPessoaRepository _repository;

    public ObterPessoaPorIdUseCase(IPessoaRepository repository)
    {
        _repository = repository;
    }

    public Task<Pessoa?> ExecuteAsync(Guid id, CancellationToken cancellationToken = default) =>
        _repository.ObterPorIdAsync(id, cancellationToken);
}
