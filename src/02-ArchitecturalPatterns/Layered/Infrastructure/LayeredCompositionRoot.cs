using ArchitecturalPatterns.Layered.Application;
using ArchitecturalPatterns.Layered.Presentation;
using Shared.Domain.Repositories;

namespace ArchitecturalPatterns.Layered.Infrastructure;

public static class LayeredCompositionRoot
{
    public static PessoaController BuildPessoaController(IPessoaRepository repository)
    {
        var application = new PessoaAppService(repository);
        return new PessoaController(application);
    }
}
