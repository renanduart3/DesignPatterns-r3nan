using System;
using DesignPatterns.DependencyInjection.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.DependencyInjection;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Dependency Injection sample");

        var services = new ServiceCollection();
        services.AddScoped<ITaskWorkerService, TaskWorkerService>();
        services.AddScoped<Worker>();

        using var provider = services.BuildServiceProvider();
        var worker = provider.GetRequiredService<Worker>();

        worker.ExecuteTaskWork("Wash your hands");
    }
}
