using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shared.Domain.Entities;
using Shared.Domain.Repositories;

namespace ArchitecturalPatterns.MVC.Services;

public class PessoaService
{
    private readonly IPessoaRepository _repository;

    public PessoaService(IPessoaRepository repository)
    {
        _repository = repository;
    }

    public Task<Pessoa> CadastrarAsync(string nome, DateTime dataNascimento, CancellationToken cancellationToken = default)
    {
        var pessoa = new Pessoa(Guid.NewGuid(), nome, dataNascimento);
        return _repository.CadastrarAsync(pessoa, cancellationToken);
    }

    public async Task<IReadOnlyCollection<Pessoa>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var pessoas = await _repository.ListarAsync(cancellationToken).ConfigureAwait(false);
        return pessoas.OrderBy(p => p.Nome).ToList();
    }

    public Task<Pessoa?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        _repository.ObterPorIdAsync(id, cancellationToken);
}
