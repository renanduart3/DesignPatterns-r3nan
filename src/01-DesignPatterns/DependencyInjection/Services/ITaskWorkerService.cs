namespace DesignPatterns.DependencyInjection.Services;

public interface ITaskWorkerService
{
    string ExecuteTaskWork(string taskName);
}
