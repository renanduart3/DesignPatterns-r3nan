using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArchitecturalPatterns.CleanArchitecture.Application.UseCases;
using Shared.Domain.Entities;

namespace ArchitecturalPatterns.CleanArchitecture.Presentation;

public class PessoaController
{
    private readonly CadastrarPessoaUseCase _cadastrar;
    private readonly ListarPessoasUseCase _listar;
    private readonly ObterPessoaPorIdUseCase _obter;

    public PessoaController(
        CadastrarPessoaUseCase cadastrar,
        ListarPessoasUseCase listar,
        ObterPessoaPorIdUseCase obter)
    {
        _cadastrar = cadastrar;
        _listar = listar;
        _obter = obter;
    }

    public async Task<PessoaResponse> CadastrarAsync(string nome, DateTime dataNascimento, CancellationToken cancellationToken = default)
    {
        var pessoa = await _cadastrar.ExecuteAsync(nome, dataNascimento, cancellationToken).ConfigureAwait(false);
        return PessoaResponse.FromEntity(pessoa);
    }

    public async Task<IReadOnlyCollection<PessoaResponse>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var pessoas = await _listar.ExecuteAsync(cancellationToken).ConfigureAwait(false);
        return pessoas.Select(PessoaResponse.FromEntity).ToList();
    }

    public async Task<PessoaResponse?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var pessoa = await _obter.ExecuteAsync(id, cancellationToken).ConfigureAwait(false);
        return pessoa is null ? null : PessoaResponse.FromEntity(pessoa);
    }
}

public record PessoaResponse(Guid Id, string Nome, int Idade)
{
    public static PessoaResponse FromEntity(Pessoa pessoa) =>
        new(pessoa.Id, pessoa.Nome, pessoa.CalcularIdade(DateTime.UtcNow));
}
