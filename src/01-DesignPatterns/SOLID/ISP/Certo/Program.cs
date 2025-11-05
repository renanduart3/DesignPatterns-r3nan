using System;
using Shared.Entities;

namespace _01_DesignPatterns.SOLID.ISP.Certo;

public static class Program
{
    public static async System.Threading.Tasks.Task Main()
    {
        var repository = new UserRepository();

        var user = new User(Guid.NewGuid(), "João da Silva", "joao.silva@example.com");
        await repository.AddAsync(user);

        var recovered = await repository.GetByEmailAsync("joao.silva@example.com");

        Console.WriteLine($"Usuário encontrado: {recovered?.Name ?? "não localizado"}");
    }
}
