using ArchitecturalPatterns.CleanArchitecture.Application.UseCases;
using ArchitecturalPatterns.CleanArchitecture.Presentation;
using Shared.Domain.Repositories;

namespace ArchitecturalPatterns.CleanArchitecture.Infrastructure;

public static class CleanArchitectureCompositionRoot
{
    public static PessoaController BuildPessoaController(IPessoaRepository repository)
    {
        var cadastrar = new CadastrarPessoaUseCase(repository);
        var listar = new ListarPessoasUseCase(repository);
        var obter = new ObterPessoaPorIdUseCase(repository);
        return new PessoaController(cadastrar, listar, obter);
    }
}
