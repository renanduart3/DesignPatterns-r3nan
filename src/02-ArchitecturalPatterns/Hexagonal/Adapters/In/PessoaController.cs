using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArchitecturalPatterns.Hexagonal.Application;
using Shared.Domain.Entities;

namespace ArchitecturalPatterns.Hexagonal.Adapters.In;

public class PessoaController
{
    private readonly PessoaApplicationService _applicationService;

    public PessoaController(PessoaApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    public Task<Pessoa> RegistrarAsync(string nome, DateTime dataNascimento, CancellationToken cancellationToken = default) =>
        _applicationService.RegistrarAsync(nome, dataNascimento, cancellationToken);

    public async Task<IReadOnlyCollection<object>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var pessoas = await _applicationService.ListarAsync(cancellationToken).ConfigureAwait(false);
        return pessoas
            .Select(pessoa => new
            {
                pessoa.Id,
                pessoa.Nome,
                Idade = pessoa.CalcularIdade(DateTime.UtcNow)
            })
            .ToList();
    }

    public async Task<object?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var pessoa = await _applicationService.ObterPorIdAsync(id, cancellationToken).ConfigureAwait(false);
        return pessoa is null
            ? null
            : new
            {
                pessoa.Id,
                pessoa.Nome,
                Idade = pessoa.CalcularIdade(DateTime.UtcNow)
            };
    }
}
