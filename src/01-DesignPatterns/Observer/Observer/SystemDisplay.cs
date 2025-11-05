using Observer.Interface;
using Observer.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Subjects
{
	public class SystemDisplay : IWheatherObserver
	{
		public readonly IWheaterSubject _wheatherEngine;
		public float Temperature { get; set; }
		public float Humidity { get; set; }
		public float Pressure { get; set; }

		public SystemDisplay(IWheaterSubject wheaterEngine)
		{
			_wheatherEngine = wheaterEngine;
			wheaterEngine.RegisterObserver(this);
		}

		void ShowDisplay(string up = "")
		{
			Console.WriteLine($"{up}\nTemp: {Temperature}\nHumidity: {Humidity}\nPressure: {Pressure}");
		}

		public void Update(float temp, float humidity, float pressure)
		{
			Temperature = temp;
			Humidity = humidity;
			Pressure = pressure;
			ShowDisplay(":Updated:");
		}
	}
}
