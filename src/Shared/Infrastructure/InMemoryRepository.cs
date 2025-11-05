using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Infrastructure;

public class InMemoryRepository<TKey, TEntity>
    where TKey : notnull
    where TEntity : class
{
    private readonly ConcurrentDictionary<TKey, TEntity> _entities = new();

    public IReadOnlyCollection<TEntity> Todos => _entities.Values.ToList().AsReadOnly();

    public virtual TEntity? ObterPorId(TKey id)
        => _entities.TryGetValue(id, out var entity) ? entity : null;

    public virtual void Salvar(TKey id, TEntity entidade)
    {
        _entities[id] = entidade;
    }

    public virtual bool Remover(TKey id)
        => _entities.TryRemove(id, out _);

    public void Limpar()
        => _entities.Clear();
}
