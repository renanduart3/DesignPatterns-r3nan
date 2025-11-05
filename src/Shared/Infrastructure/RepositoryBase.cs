using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entities;

namespace Shared.Infrastructure;

public class RepositoryBase<TEntity>
    where TEntity : class, IEntity
{
    private readonly ConcurrentDictionary<Guid, TEntity> _storage = new();

    public virtual Task<TEntity?> GetByIdAsync(Guid id)
    {
        _storage.TryGetValue(id, out var entity);
        return Task.FromResult(entity);
    }

    public virtual Task<IReadOnlyCollection<TEntity>> GetAllAsync()
    {
        IReadOnlyCollection<TEntity> items = _storage.Values.ToList();
        return Task.FromResult(items);
    }

    public virtual Task<bool> ExistsAsync(Guid id)
    {
        return Task.FromResult(_storage.ContainsKey(id));
    }

    public virtual Task AddAsync(TEntity entity)
    {
        _storage.AddOrUpdate(entity.Id, entity, (_, _) => entity);
        return Task.CompletedTask;
    }

    public virtual Task UpdateAsync(TEntity entity)
    {
        _storage.AddOrUpdate(entity.Id, entity, (_, _) => entity);
        return Task.CompletedTask;
    }

    public virtual Task RemoveAsync(Guid id)
    {
        _storage.TryRemove(id, out _);
        return Task.CompletedTask;
    }
}
