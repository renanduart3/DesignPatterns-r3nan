using dependency_injection_console.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace dependency_injection_console
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World");
			//Adding dependency injection service collection
			var services = new ServiceCollection();
			
			services.AddScoped<ITaskWorkerService, TaskWorkerService>();
			services.AddScoped<Worker, Worker>();

			var provider = services.BuildServiceProvider();

			var worker = provider.GetService<Worker>();

			worker.ExecuteTaskWork("Wash your hands");


		}
	}
}
