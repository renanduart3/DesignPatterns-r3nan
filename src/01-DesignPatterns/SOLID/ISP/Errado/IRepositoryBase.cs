using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Entities;

namespace _01_DesignPatterns.SOLID.ISP.Errado;

/// <summary>
///     Exemplo propositalmente errado do ISP: um repositório genérico que
///     obriga todos os consumidores a conhecerem detalhes de <see cref="User"/>.
/// </summary>
/// <typeparam name="TEntity">Tipo da entidade a ser persistida.</typeparam>
public interface IRepositoryBase<TEntity>
{
    Task<TEntity?> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task RemoveAsync(Guid id);

    // Método específico que quebra o ISP por forçar todos a implementarem uma busca por e-mail.
    Task<User?> GetByEmailAsync(string email);
}
