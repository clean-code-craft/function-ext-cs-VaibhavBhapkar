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
        if (batteryFactors.temperatureMesureUnit == "Fahrenheit")
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
                if (operatingLanguage == "English")
                {
                    Display.PrintMessage(temperatureValue.Value.Item1);
                    AccumulateBreachedFeatures("Temperature", temperatureValue.Value.Item1, temperatureValue.Value.Item3);
                }
                else
                {
                    Display.PrintMessage(temperatureValue.Value.Item2);
                    AccumulateBreachedFeatures("Temperature", temperatureValue.Value.Item2, temperatureValue.Value.Item3);
                }

            }
        }
    }
    public void CompareStateOfChargeWithRange(float stateOfCharge, string operatingLanguage)
    {
        foreach (var socValue in BatteryLimits.stateOfChargeBoundary)
        {
            if (socValue.Key.InRange(stateOfCharge))
            {
                if (operatingLanguage == "English")
                {
                    Display.PrintMessage(socValue.Value.Item1);
                    AccumulateBreachedFeatures("State Of Charge", socValue.Value.Item1, socValue.Value.Item3);
                }
                else
                {
                    Display.PrintMessage(socValue.Value.Item2);
                    AccumulateBreachedFeatures("State Of Charge", socValue.Value.Item2, socValue.Value.Item3);
                }
            }
        }
    }
    public void CompareChargeRateWithRange(float chargeRate, string operatingLanguage)
    {
        foreach (var chargeRateValue in BatteryLimits.chargeRateBoundary)
        {
            if (chargeRateValue.Key.InRange(chargeRate))
            {
                if (operatingLanguage == "English")
                {
                    Display.PrintMessage(chargeRateValue.Value.Item1);
                    AccumulateBreachedFeatures("Charge Rate", chargeRateValue.Value.Item1, chargeRateValue.Value.Item3);
                }
                else
                {
                    Display.PrintMessage(chargeRateValue.Value.Item2);
                    AccumulateBreachedFeatures("Charge Rate", chargeRateValue.Value.Item2, chargeRateValue.Value.Item3);
                }
            }
        }
    }
    public void AccumulateBreachedFeatures(string parameterName, string parameterValue, string parameterStatus)
    {
        if (parameterStatus == "Breach")
        {
            batteryAlerts.Add(parameterName, parameterValue);
        }
    }

}

