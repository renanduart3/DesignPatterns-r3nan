using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Shared.Domain.Entities;
using Shared.Domain.Repositories;

namespace ArchitecturalPatterns.BFF.Services;

public class PessoaBffService
{
    private readonly IPessoaRepository _repository;

    public PessoaBffService(IPessoaRepository repository)
    {
        _repository = repository;
    }

    public Task<Pessoa> CriarPerfilAsync(string nome, DateTime dataNascimento, CancellationToken cancellationToken = default)
    {
        var pessoa = new Pessoa(Guid.NewGuid(), nome, dataNascimento);
        return _repository.CadastrarAsync(pessoa, cancellationToken);
    }

    public async Task<IReadOnlyCollection<PessoaResumo>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var pessoas = await _repository.ListarAsync(cancellationToken).ConfigureAwait(false);
        return pessoas
            .Select(pessoa => new PessoaResumo(pessoa.Id, pessoa.Nome))
            .ToList();
    }

    public async Task<PessoaDetalhe?> ObterDetalhesAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var pessoa = await _repository.ObterPorIdAsync(id, cancellationToken).ConfigureAwait(false);
        return pessoa is null
            ? null
            : new PessoaDetalhe(
                pessoa.Id,
                pessoa.Nome,
                pessoa.CalcularIdade(DateTime.UtcNow),
                pessoa.DataNascimento);
    }
}

public record PessoaResumo(Guid Id, string Nome);

public record PessoaDetalhe(Guid Id, string Nome, int Idade, DateTime DataNascimento);
