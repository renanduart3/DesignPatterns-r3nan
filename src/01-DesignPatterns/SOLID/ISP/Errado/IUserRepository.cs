using Shared.Entities;

namespace _01_DesignPatterns.SOLID.ISP.Errado;

/// <summary>
///     Exemplo que viola o ISP ao herdar um contrato com operações desnecessárias.
/// </summary>
public interface IUserRepository : IRepositoryBase<User>
{
}
