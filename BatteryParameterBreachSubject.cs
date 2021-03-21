using System;
using System.Collections.Generic;
using System.Text;


public class BatteryParameterBreachSubject : ISubject
{
    private List<IObserver> _observers;
    public string BatteryParameter = string.Empty;
    public string BatteryMessage = string.Empty;
    public BatteryParameterBreachSubject()
    {
        _observers = new List<IObserver>();

    }
    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }
    public void Notify()
    {
        _observers.ForEach(observe => {
            observe.Update(this);
        });
    }
    public void BatteryFeaturesBreachCheck(BatteryFactors batteryFactors)
    {
        CheckTemperatureBreach(batteryFactors.batteryTemprature);
        CheckStateOfChargeBreach(batteryFactors.batteryStateOfCharge);
        CheckChargeRateBreach(batteryFactors.batteryChargeRate);
    }
    private void CheckTemperatureBreach(float batteryTemperature)
    {
        foreach (var temperatureValue in BatteryLimits.temperatureBoundary)
        {
            if (temperatureValue.Key.InRange(batteryTemperature))
            {
                if (temperatureValue.Value.Item2 == BatteryFactors.BatteryStatus.Breach)
                {
                    this.BatteryParameter = CultureInformation.GetCultureInformation().GetString("BreachMessage") + "-" + CultureInformation.GetCultureInformation().GetString("Temp");
                    this.BatteryMessage = temperatureValue.Value.Item1;
                    Notify();
                }
            }
        }
    }
    private void CheckStateOfChargeBreach(float soc)
    {
        foreach (var socValue in BatteryLimits.stateOfChargeBoundary)
        {
            if (socValue.Key.InRange(soc))
            {
                if (socValue.Value.Item2 == BatteryFactors.BatteryStatus.Breach)
                {
                    this.BatteryParameter = CultureInformation.GetCultureInformation().GetString("BreachMessage") + "-" + CultureInformation.GetCultureInformation().GetString("SOC");
                    this.BatteryMessage = socValue.Value.Item1;
                    Notify();
                }
            }
        }
    }
    private void CheckChargeRateBreach(float chargeRate)
    {
        foreach (var chargeRateValue in BatteryLimits.chargeRateBoundary)
        {
            if (chargeRateValue.Key.InRange(chargeRate))
            {
                if (chargeRateValue.Value.Item2 == BatteryFactors.BatteryStatus.Breach)
                {
                    this.BatteryParameter = CultureInformation.GetCultureInformation().GetString("BreachMessage") + "-" + CultureInformation.GetCultureInformation().GetString("CR");
                    this.BatteryMessage = chargeRateValue.Value.Item1;
                    Notify();
                }
            }
        }
    }
}

