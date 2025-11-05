using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArchitecturalPatterns.Layered.Application;
using Shared.Domain.Entities;

namespace ArchitecturalPatterns.Layered.Presentation;

public class PessoaController
{
    private readonly PessoaAppService _applicationService;

    public PessoaController(PessoaAppService applicationService)
    {
        _applicationService = applicationService;
    }

    public Task<Pessoa> RegistrarAsync(string nome, DateTime dataNascimento, CancellationToken cancellationToken = default) =>
        _applicationService.RegistrarAsync(nome, dataNascimento, cancellationToken);

    public async Task<IEnumerable<object>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var pessoas = await _applicationService.ListarAsync(cancellationToken).ConfigureAwait(false);
        return pessoas.Select(pessoa => new
        {
            pessoa.Id,
            pessoa.Nome,
            Idade = pessoa.CalcularIdade(DateTime.UtcNow)
        });
    }
}
