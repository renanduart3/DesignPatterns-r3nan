using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Shared.Domain.Entities;
using Shared.Domain.Repositories;

namespace ArchitecturalPatterns.Layered.Application;

public class PessoaAppService
{
    private readonly IPessoaRepository _repository;

    public PessoaAppService(IPessoaRepository repository)
    {
        _repository = repository;
    }

    public Task<Pessoa> RegistrarAsync(string nome, DateTime dataNascimento, CancellationToken cancellationToken = default)
    {
        var pessoa = new Pessoa(Guid.NewGuid(), nome, dataNascimento);
        return _repository.CadastrarAsync(pessoa, cancellationToken);
    }

    public Task<IReadOnlyCollection<Pessoa>> ListarAsync(CancellationToken cancellationToken = default) =>
        _repository.ListarAsync(cancellationToken);
}
