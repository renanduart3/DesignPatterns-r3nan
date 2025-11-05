using ArchitecturalPatterns.BFF.Controllers;
using ArchitecturalPatterns.BFF.Services;
using Shared.Domain.Repositories;

namespace ArchitecturalPatterns.BFF;

public static class BffCompositionRoot
{
    public static PessoaBffController BuildPessoaController(IPessoaRepository repository)
    {
        var service = new PessoaBffService(repository);
        return new PessoaBffController(service);
    }
}
