using System;
using System.Collections.Generic;
using System.Text;


public class AccumulateBreachParameter : IObserver
{
    Dictionary<string, string> breachedParameterList = new Dictionary<string, string>();
    public AccumulateBreachParameter()
    {
        breachedParameterList.Clear();
    }
    public void Update(ISubject subject)
    {
        if (subject is BatteryParameterBreachSubject batteryParameterBreachSubject)
        {
            breachedParameterList.Add(batteryParameterBreachSubject.BatteryParameter, batteryParameterBreachSubject.BatteryMessage);
        }
    }
    public Dictionary<string, string> GetReport()
    {
        return breachedParameterList;
    }
}

