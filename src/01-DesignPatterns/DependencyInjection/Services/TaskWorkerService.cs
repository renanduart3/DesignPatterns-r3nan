using System;

namespace DesignPatterns.DependencyInjection.Services;

public class TaskWorkerService : ITaskWorkerService
{
    public string ExecuteTaskWork(string taskName)
    {
        return $"{taskName} {DateTime.Now:dd/MM/yyyy}";
    }
}
