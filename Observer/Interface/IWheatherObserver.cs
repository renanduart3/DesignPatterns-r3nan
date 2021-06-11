using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Interface
{
	public interface IWheatherObserver
	{
		void Update(float temp, float humidity, float pressure);
	}
}
