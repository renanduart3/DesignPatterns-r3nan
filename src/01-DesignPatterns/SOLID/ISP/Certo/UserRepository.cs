using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entities;
using Shared.Infrastructure;

namespace _01_DesignPatterns.SOLID.ISP.Certo;

public sealed class UserRepository : IUserRepository
{
    private readonly RepositoryBase<User> _repositoryBase;
    private readonly ConcurrentDictionary<string, Guid> _emailIndex = new(StringComparer.OrdinalIgnoreCase);

    public UserRepository()
        : this(new RepositoryBase<User>())
    {
    }

    public UserRepository(RepositoryBase<User> repositoryBase)
    {
        _repositoryBase = repositoryBase;
    }

    public Task<User?> GetByIdAsync(Guid id) => _repositoryBase.GetByIdAsync(id);

    public Task<IReadOnlyCollection<User>> GetAllAsync() => _repositoryBase.GetAllAsync();

    public async Task AddAsync(User user)
    {
        await _repositoryBase.AddAsync(user).ConfigureAwait(false);
        _emailIndex[user.Email] = user.Id;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        if (_emailIndex.TryGetValue(email, out var id))
        {
            return await _repositoryBase.GetByIdAsync(id).ConfigureAwait(false);
        }

        var users = await _repositoryBase.GetAllAsync().ConfigureAwait(false);
        var user = users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        if (user is not null)
        {
            _emailIndex[email] = user.Id;
        }

        return user;
    }
}
