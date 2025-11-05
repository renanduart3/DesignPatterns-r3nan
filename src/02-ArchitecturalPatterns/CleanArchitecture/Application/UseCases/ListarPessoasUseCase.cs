using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shared.Domain.Entities;
using Shared.Domain.Repositories;

namespace ArchitecturalPatterns.CleanArchitecture.Application.UseCases;

public class ListarPessoasUseCase
{
    private readonly IPessoaRepository _repository;

    public ListarPessoasUseCase(IPessoaRepository repository)
    {
        _repository = repository;
    }

    public Task<IReadOnlyCollection<Pessoa>> ExecuteAsync(CancellationToken cancellationToken = default) =>
        _repository.ListarAsync(cancellationToken);
}
