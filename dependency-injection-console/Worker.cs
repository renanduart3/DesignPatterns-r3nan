using dependency_injection_console.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection_console
{
	public class Worker
	{
		private readonly ITaskWorkerService _taskWorkerService;

		public Worker(ITaskWorkerService taskWorkerService)
			=> _taskWorkerService = taskWorkerService;

		public void ExecuteTaskWork(string taskName)
		{
			var tasRealkName = _taskWorkerService.ExecuteTaskWork(taskName);
			Console.WriteLine($"Task: ({tasRealkName}) running...");
		}


	}
}
