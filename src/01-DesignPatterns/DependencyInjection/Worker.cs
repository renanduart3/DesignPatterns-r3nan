using System;
using DesignPatterns.DependencyInjection.Services;

namespace DesignPatterns.DependencyInjection;

public class Worker
{
    private readonly ITaskWorkerService _taskWorkerService;

    public Worker(ITaskWorkerService taskWorkerService)
    {
        _taskWorkerService = taskWorkerService;
    }

    public void ExecuteTaskWork(string taskName)
    {
        var taskRealName = _taskWorkerService.ExecuteTaskWork(taskName);
        Console.WriteLine($"Task: ({taskRealName}) running...");
    }
}
