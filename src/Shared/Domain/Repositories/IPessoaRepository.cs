using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shared.Domain.Entities;

namespace Shared.Domain.Repositories;

public interface IPessoaRepository
{
    Task<Pessoa> CadastrarAsync(Pessoa pessoa, CancellationToken cancellationToken = default);
    Task<Pessoa?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Pessoa>> ListarAsync(CancellationToken cancellationToken = default);
}
