using Observer.Core;
using Observer.Subjects;
using System;

namespace Observer
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			WheaterData whaterData = new WheaterData();
			SystemDisplay display = new SystemDisplay(whaterData);

			whaterData.setMeasurements(30.2f,40.1f,12.12f);
			whaterData.setMeasurements(10.2f,20.1f,12.79f);
			whaterData.setMeasurements(5.37f,40.1f,12.12f);

		}
	}
}
