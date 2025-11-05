using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Entities;

namespace _01_DesignPatterns.SOLID.ISP.Certo;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<IReadOnlyCollection<User>> GetAllAsync();
    Task AddAsync(User user);
    Task<User?> GetByEmailAsync(string email);
}
