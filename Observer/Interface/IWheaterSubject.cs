using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Interface
{
	public interface IWheaterSubject
	{
		void RegisterObserver(IWheatherObserver o);
		void RemoveObserver(IWheatherObserver o);
		void NotifyObservers();
	}
}
