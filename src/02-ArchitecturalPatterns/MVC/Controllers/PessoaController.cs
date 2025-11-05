using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ArchitecturalPatterns.MVC.Models;
using ArchitecturalPatterns.MVC.Services;

namespace ArchitecturalPatterns.MVC.Controllers;

public class PessoaController
{
    private readonly PessoaService _service;

    public PessoaController(PessoaService service)
    {
        _service = service;
    }

    public async Task<PessoaViewModel> CadastrarAsync(PessoaInputModel input, CancellationToken cancellationToken = default)
    {
        var pessoa = await _service.CadastrarAsync(input.Nome, input.DataNascimento, cancellationToken)
            .ConfigureAwait(false);

        return PessoaViewModel.FromEntity(pessoa, DateTime.UtcNow);
    }

    public async Task<IReadOnlyCollection<PessoaViewModel>> ListarAsync(CancellationToken cancellationToken = default)
    {
        var pessoas = await _service.ListarAsync(cancellationToken).ConfigureAwait(false);
        return pessoas
            .Select(pessoa => PessoaViewModel.FromEntity(pessoa, DateTime.UtcNow))
            .ToList();
    }

    public async Task<PessoaViewModel?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var pessoa = await _service.ObterPorIdAsync(id, cancellationToken).ConfigureAwait(false);
        return pessoa is null ? null : PessoaViewModel.FromEntity(pessoa, DateTime.UtcNow);
    }
}
