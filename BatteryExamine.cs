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
                switch (kvp.Value)
                {
                    case "LOW_TEMPERATURE_BREACH":
                        message = (operatingLanguage == "German") ? "Die Temperatur ist im Vergleich zu den Mindestgrenzwerten niedrig" : "The temperature is low compared to the minimum limits";
                        DisplayMessage(message);
                        break;
                    case "LOW_TEMPERATURE_WARNING":
                        message = (operatingLanguage == "German") ? "Warnung! Die Temperatur nähert sich dem Mindestgrenzwert" : "Warning! Temperature is heading towards minimum limit value";
                        DisplayMessage(message);
                        break;
                    case "NORMAL":
                        message = (operatingLanguage == "German") ? "Die Temperatur ist normal" : "Temperature is Normal";
                        DisplayMessage(message);
                        break;
                    case "HIGH_TEMPERATURE_WARNING":
                        message = (operatingLanguage == "German") ? "Warnung! Die Temperatur nähert sich dem maximalen Grenzwert" : "Warning! Temperature is heading towards maximum limit value";
                        DisplayMessage(message);
                        break;
                    case "HIGH_TEMPERATURE_BREACH":
                        message = (operatingLanguage == "German") ? "Die Temperatur ist im Vergleich zu den Höchstgrenzen hoch" : "The temperature is high compared to the maximum limits";
                        DisplayMessage(message);
                        break;
                }                
            }
        }
    }
    public void CompareStateOfChargeWithRange(float stateOfCharge,string operatingLanguage)
    {
        foreach (var kvp in BatteryLimits.stateOfChargeBoundary)
        {
            if (kvp.Key.InRange(stateOfCharge))
            {
                switch (kvp.Value)
                {
                    case "LOW_SOC_BREACH":
                        message = (operatingLanguage == "German") ? "Der Ladezustand ist im Vergleich zu den Mindestgrenzen niedrig" : "The state of charge is low compared to the minimum limits";
                        DisplayMessage(message);
                        break;
                    case "LOW_SOC_WARNING":
                        message = (operatingLanguage == "German") ? "Warnung! Der Ladezustand nähert sich dem Mindestgrenzwert" : "Warning! State of charge is heading towards minimum limit value";
                        DisplayMessage(message);
                        break;
                    case "NORMAL":
                        message = (operatingLanguage == "German") ? "Der Ladezustand ist normal" : "State of Charge is Normal";
                        DisplayMessage(message);
                        break;
                    case "HIGH_SOC_WARNING":
                        message = (operatingLanguage == "German") ? "Warnung! Der Ladezustand nähert sich dem maximalen Grenzwert" : "Warning! State of charge is heading towards maximum limit value";
                        DisplayMessage(message);
                        break;
                    case "HIGH_SOC_BREACH":
                        message = (operatingLanguage == "German") ? "Der Ladezustand ist im Vergleich zu den Höchstgrenzen hoch" : "The state of charge is high compared to the maximum limits";
                        DisplayMessage(message);
                        break;
                }
            }
        }
    }
    public void CompareChargeRateWithRange(float chargeRate,string operatingLanguage)
    {
        foreach (var kvp in BatteryLimits.chargeRateBoundary)
        {
            if (kvp.Key.InRange(chargeRate))
            {
                switch (kvp.Value)
                {                    
                    case "NORMAL":
                        message = (operatingLanguage == "German") ? "Laderate ist normal" : "Charge Rate is Normal";
                        DisplayMessage(message);
                        break;
                    case "HIGH_CHARGERATE_WARNING":
                        message = (operatingLanguage == "German") ? "Warnung! Der Gebührensatz bewegt sich in Richtung des maximalen Grenzwerts" : "Warning! Charge rate is heading towards maximum limit value";
                        DisplayMessage(message);
                        break;
                    case "HIGH_CHARGERATE_BREACH":
                        message = (operatingLanguage == "German") ? "Die Laderate ist im Vergleich zu den Höchstgrenzen hoch" : "The charge rate is high compared to the maximum limits";
                        DisplayMessage(message);
                        break;
                }
            }
        }
    }
    static void DisplayMessage(string displayMessage)
    {
        Console.WriteLine(displayMessage);
    }

}

