using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shared.Domain.Entities;
using Shared.Domain.Repositories;

namespace Shared.Infrastructure.Persistence;

public class InMemoryPessoaRepository : IPessoaRepository
{
    private readonly ConcurrentDictionary<Guid, Pessoa> _storage = new();

    public Task<Pessoa> CadastrarAsync(Pessoa pessoa, CancellationToken cancellationToken = default)
    {
        _storage[pessoa.Id] = pessoa;
        return Task.FromResult(pessoa);
    }

    public Task<IReadOnlyCollection<Pessoa>> ListarAsync(CancellationToken cancellationToken = default)
    {
        IReadOnlyCollection<Pessoa> pessoas = _storage.Values
            .OrderBy(p => p.Nome)
            .ToList();
        return Task.FromResult(pessoas);
    }

    public Task<Pessoa?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        _storage.TryGetValue(id, out var pessoa);
        return Task.FromResult(pessoa);
    }
}
