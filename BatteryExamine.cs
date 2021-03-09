using System;
using System.Collections.Generic;
using System.Text;


public class BatteryExamine
{
    string message = string.Empty;
    public void BatteryIsOk(BatteryFactors batteryFactors)
    {
        CompareTemperatureWithRange(batteryFactors.batteryTemprature,batteryFactors.operatingLanguage);
        CompareStateOfChargeWithRange(batteryFactors.batteryStateOfCharge,batteryFactors.operatingLanguage);
        CompareChargeRateWithRange(batteryFactors.batteryChargeRate,batteryFactors.operatingLanguage);
    }
    private void CompareTemperatureWithRange(float batteryTemperature,string operatingLanguage)
    {
        foreach (var temperatureValue in BatteryLimits.temperatureBoundary)
        {
            if (temperatureValue.Key.InRange(batteryTemperature))
            {
                if (operatingLanguage == "English")
                {
                    DisplayMessage(temperatureValue.Value.Item1);
                }
                else
                {
                    DisplayMessage(temperatureValue.Value.Item2);
                }
            }
        }
    }
    public void CompareStateOfChargeWithRange(float stateOfCharge,string operatingLanguage)
    {
        foreach (var socValue in BatteryLimits.stateOfChargeBoundary)
        {
            if (socValue.Key.InRange(stateOfCharge))
            {
                if(operatingLanguage=="English")
                {
                    DisplayMessage(socValue.Value.Item1);
                }
                else
                {
                    DisplayMessage(socValue.Value.Item2);
                }
            }
        }
    }
    public void CompareChargeRateWithRange(float chargeRate,string operatingLanguage)
    {
        foreach (var chargeRateValue in BatteryLimits.chargeRateBoundary)
        {
            if (chargeRateValue.Key.InRange(chargeRate))
            {
                if (operatingLanguage == "English")
                {
                    DisplayMessage(chargeRateValue.Value.Item1);
                }
                else
                {
                    DisplayMessage(chargeRateValue.Value.Item2);
                }
            }
        }
    }
    static void DisplayMessage(string displayMessage)
    {
        Console.WriteLine(displayMessage);
    }

}

