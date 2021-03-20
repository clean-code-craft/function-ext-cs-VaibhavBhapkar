using System;
using System.Collections.Generic;

class Checker
{
    static void Main()
    {
        float temperatureInput, stateOfChargeInput, chargeRateInput;
        string languageInput = string.Empty;
        languageInput = GetLanguageInput();
        temperatureInput = GetTemperatureUnit(languageInput);
        stateOfChargeInput = GetStateOfChargeInput(languageInput);
        chargeRateInput = GetChargeRateInput(languageInput);
        BatteryExamine batteryExamine = new BatteryExamine();
        batteryExamine.BatteryIsOk(new BatteryFactors(temperatureInput, stateOfChargeInput, chargeRateInput, languageInput));
    }

    static string GetLanguageInput()
    {
        DisplayMessage("Please select language 1.English 2.German");
        int languageChoice = Convert.ToInt32(Console.ReadLine());
        if (languageChoice == 1)
        {
            return "English";
        }
        else if (languageChoice == 2)
        {
            return "German";
        }
        else
        {
            DisplayMessage("Please Enter valid value");
            Environment.Exit(0);
            return "Wrong Input";
        }
    }
    static float GetTemperatureUnit(string language)
    {
        string message = string.Empty;
        int temperatureUnit;
        message = (language == "English") ? "Please provide temperature unit 1.Celsius 2.Fahrenheit" : "Bitte Temperatureinheit 1.Celsius 2.Fahrenheit angeben";
        DisplayMessage(message);
        temperatureUnit = Convert.ToInt32(Console.ReadLine());
        return GetTemperatureValue(temperatureUnit, language);
    }
    static float GetTemperatureValue(int tempUnit, string language)
    {
        string message = string.Empty;
        message = (language == "English") ? "Please provide temperature value" : "Bitte geben Sie den Temperaturwert an";
        DisplayMessage(message);
        if (tempUnit == 1)
        {
            return float.Parse(Console.ReadLine());
        }
        else
        {
            return ConvertTemperatureCelsiusToFahrenheit(float.Parse(Console.ReadLine()));
        }
    }
    static float GetStateOfChargeInput(string language)
    {
        string message = string.Empty;
        message = (language == "English") ? "Please provide state of charge value:" : "Bitte geben Sie den Ladezustand an:";
        DisplayMessage(message);
        return float.Parse(Console.ReadLine());
    }
    static float GetChargeRateInput(string language)
    {
        string message = string.Empty;
        message = (language == "English") ? "Please provide charge rate value:" : "Bitte geben Sie den Gebührenwert an:";
        DisplayMessage(message);
        return float.Parse(Console.ReadLine());

    }
    static void DisplayMessage(string inputMessage)
    {
        Console.WriteLine(inputMessage);
    }
    static float ConvertTemperatureCelsiusToFahrenheit(float fahrenheitTemp)
    {
        return (fahrenheitTemp - 32) * 5 / 9;
    }
}

