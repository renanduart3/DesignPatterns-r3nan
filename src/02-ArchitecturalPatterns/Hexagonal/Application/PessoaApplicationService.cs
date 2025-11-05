using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shared.Domain.Entities;
using Shared.Domain.Repositories;

namespace ArchitecturalPatterns.Hexagonal.Application;

public class PessoaApplicationService
{
    private readonly IPessoaRepository _pessoaRepository;

    public PessoaApplicationService(IPessoaRepository pessoaRepository)
    {
        _pessoaRepository = pessoaRepository;
    }

    public Task<Pessoa> RegistrarAsync(string nome, DateTime dataNascimento, CancellationToken cancellationToken = default)
    {
        var pessoa = new Pessoa(Guid.NewGuid(), nome, dataNascimento);
        return _pessoaRepository.CadastrarAsync(pessoa, cancellationToken);
    }

    public Task<IReadOnlyCollection<Pessoa>> ListarAsync(CancellationToken cancellationToken = default) =>
        _pessoaRepository.ListarAsync(cancellationToken);

    public Task<Pessoa?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        _pessoaRepository.ObterPorIdAsync(id, cancellationToken);
}
