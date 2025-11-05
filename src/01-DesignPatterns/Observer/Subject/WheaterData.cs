using Observer.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Core
{
	public class WheaterData : IWheaterSubject
	{
		private ArrayList observers;
		private float Temperature { get; set; }
		private float Humidity { get; set; }
		private float Pressure { get; set; }

		public WheaterData()
		{
			observers = new ArrayList();
		}
		float getTemperature()
		{
			return 0;
		}
		float getHumidity()
		{
			return 0;
		}

		float getPressure()
		{
			return 0;
		}

		void measurementsChangedWithoutPattern()
		{
			// get values
			float temperature = getTemperature();
			float humidity = getHumidity();
			float pressure = getPressure();

			// update system

			//currentConditionDisplay.update(temperature, humidity, pressure);
			//currentStatisticDisplay.update(temperature, humidity, pressure);
			//currentForecastDisplay.update(temperature, humidity, pressure);


		}

		// With pattern
		void measurementsChanged()
		{
			NotifyObservers();
		}

		public void setMeasurements(float temperature, float humidity, float pressure)
		{
			Temperature = temperature;
			Humidity = humidity;
			Pressure = pressure;
			measurementsChanged();
		}
		public void RegisterObserver(IWheatherObserver o)
		{
			observers.Add(o);
		}

		public void RemoveObserver(IWheatherObserver o)
		{
			observers.Remove(o);
		}

		public void NotifyObservers()
		{
			for (int i = 0; i < observers.Count; i++ )
			{
				IWheatherObserver obs = (IWheatherObserver) observers[i];
				obs.Update(Temperature, Humidity, Pressure);
			}
		}
	}
}
