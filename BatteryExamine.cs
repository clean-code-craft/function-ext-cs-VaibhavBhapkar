using System;
using System.Collections.Generic;
using System.Text;


public class BatteryExamine
{

    string message = string.Empty;
    Dictionary<string, string> batteryAlerts = new Dictionary<string, string>();
    
    public Dictionary<string, string> BatteryIsOk(BatteryFactors batteryFactors)
    {
        batteryAlerts.Clear();
        if(batteryFactors.temperatureMesureUnit== "Fahrenheit")
        {
            batteryFactors.batteryTemprature = BatteryFeatureConversion.ConvertTemperatureFahrenheitToCelsius(batteryFactors.batteryTemprature);
        }
        CompareTemperatureWithRange(batteryFactors.batteryTemprature, batteryFactors.operatingLanguage);
        CompareStateOfChargeWithRange(batteryFactors.batteryStateOfCharge, batteryFactors.operatingLanguage);
        CompareChargeRateWithRange(batteryFactors.batteryChargeRate, batteryFactors.operatingLanguage);
        return batteryAlerts;
    }
    private void CompareTemperatureWithRange(float batteryTemperature, string operatingLanguage)
    {
        foreach (var temperatureValue in BatteryLimits.temperatureBoundary)
        {
            if (temperatureValue.Key.InRange(batteryTemperature))
            {
                AccumulateBreachedFeatures(temperatureValue.Value, operatingLanguage, "Temperature");
            }
        }
    }
    public void CompareStateOfChargeWithRange(float stateOfCharge, string operatingLanguage)
    {
        foreach (var socValue in BatteryLimits.stateOfChargeBoundary)
        {
            if (socValue.Key.InRange(stateOfCharge))
            {
                AccumulateBreachedFeatures(socValue.Value, operatingLanguage, "State Of Charge");
            }
        }
    }
    public void CompareChargeRateWithRange(float chargeRate, string operatingLanguage)
    {
        foreach (var chargeRateValue in BatteryLimits.chargeRateBoundary)
        {
            if (chargeRateValue.Key.InRange(chargeRate))
            {
                AccumulateBreachedFeatures(chargeRateValue.Value, operatingLanguage, "Charge Rate");
            }
        }
    }
    public void AccumulateBreachedFeatures(Tuple<string,string,string> parameterValue,string operatingLanguage,string batteryFeature)
    {
        if (operatingLanguage == "English")
        {
            Display.PrintMessage(parameterValue.Item1);
            if (parameterValue.Item3 == "Breach")
            {
                batteryAlerts.Add(batteryFeature, parameterValue.Item1);    
            }
        }
        else
        {
            Display.PrintMessage(parameterValue.Item2);
            if (parameterValue.Item3 == "Breach")
            {
                batteryAlerts.Add(batteryFeature, parameterValue.Item2);
            }
        }
    }

}

