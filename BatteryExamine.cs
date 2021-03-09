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
        foreach (var kvp in BatteryLimits.temperatureBoundary)
        {
            if (kvp.Key.InRange(batteryTemperature))
            {
                                
            }
        }
    }
    public void CompareStateOfChargeWithRange(float stateOfCharge,string operatingLanguage)
    {
        foreach (var kvp in BatteryLimits.stateOfChargeBoundary)
        {
            if (kvp.Key.InRange(stateOfCharge))
            {
                
            }
        }
    }
    public void CompareChargeRateWithRange(float chargeRate,string operatingLanguage)
    {
        foreach (var kvp in BatteryLimits.chargeRateBoundary)
        {
            if (kvp.Key.InRange(chargeRate))
            {
            }
        }
    }
    static void DisplayMessage(string displayMessage)
    {
        Console.WriteLine(displayMessage);
    }

}

