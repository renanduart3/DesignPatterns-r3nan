using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dependency_injection_console.Services
{
	public class TaskWorkerService : ITaskWorkerService
	{

		public string ExecuteTaskWork(string taskName)
			=> taskName += $" { DateTime.Now.ToString("dd/MM/yyyy")}";
	}
}
