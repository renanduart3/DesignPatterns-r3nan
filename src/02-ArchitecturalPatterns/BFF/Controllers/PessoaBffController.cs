using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ArchitecturalPatterns.BFF.Services;

namespace ArchitecturalPatterns.BFF.Controllers;

public class PessoaBffController
{
    private readonly PessoaBffService _service;

    public PessoaBffController(PessoaBffService service)
    {
        _service = service;
    }

    public async Task<PessoaDetalhe> CriarPerfilAsync(string nome, DateTime dataNascimento, CancellationToken cancellationToken = default)
    {
        var pessoa = await _service.CriarPerfilAsync(nome, dataNascimento, cancellationToken).ConfigureAwait(false);
        return new PessoaDetalhe(pessoa.Id, pessoa.Nome, pessoa.CalcularIdade(DateTime.UtcNow), pessoa.DataNascimento);
    }

    public Task<IReadOnlyCollection<PessoaResumo>> ListarAsync(CancellationToken cancellationToken = default) =>
        _service.ListarAsync(cancellationToken);

    public Task<PessoaDetalhe?> ObterDetalhesAsync(Guid id, CancellationToken cancellationToken = default) =>
        _service.ObterDetalhesAsync(id, cancellationToken);
}
