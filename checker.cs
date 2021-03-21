using System;
using System.Collections.Generic;
using System.Resources;

class Checker
{
    static void Main()
    {
        float temperatureInput, stateOfChargeInput, chargeRateInput;
        ResourceManager resourceInfo = GetLanguageInput();
        CultureInformation.SetCultureInformation(resourceInfo);
        temperatureInput = GetTemperatureUnit();
        stateOfChargeInput = GetStateOfChargeInput();
        chargeRateInput = GetChargeRateInput();
        BatteryExamine batteryExamine = new BatteryExamine();
        bool result = batteryExamine.BatteryIsOk(new BatteryFactors(temperatureInput, stateOfChargeInput, chargeRateInput));
        BatteryParameterBreachSubject batteryParameterBreachSubject = new BatteryParameterBreachSubject();
        AccumulateBreachParameter accumulateBreachParameter = new AccumulateBreachParameter();
        batteryParameterBreachSubject.Attach(accumulateBreachParameter);
        batteryParameterBreachSubject.BatteryFeaturesBreachCheck(new BatteryFactors(temperatureInput, stateOfChargeInput, chargeRateInput));
        Dictionary<string, string> batteryAlertMessages = accumulateBreachParameter.GetReport();
        IReports iReportsCosoleLogger = new ConsoleReportLogger();
        BatteryReport batteryReportWithConsoleLogger = new BatteryReport(iReportsCosoleLogger);
        batteryReportWithConsoleLogger.ReportLogger(batteryAlertMessages);
        IReports iReportsDummyLogger = new DummyReportLogger();
        BatteryReport batteryReportWithDummyLogger = new BatteryReport(iReportsDummyLogger);
        batteryReportWithDummyLogger.ReportLogger(batteryAlertMessages);

    }
    static ResourceManager GetLanguageInput()
    {
        Display.PrintMessage("Please select language 1.English 2.German");
        int languageChoice = Convert.ToInt32(Console.ReadLine());
        if (languageChoice == 1)
        {
            ICulterSet culterSet = new EnglishCulterSetting();
            CulterHelper culterHelper = new CulterHelper(culterSet);
            return culterHelper.SetCulter();
        }
        else
        {
            ICulterSet culterSet = new GermanCulterSetting();
            CulterHelper culterHelper = new CulterHelper(culterSet);
            return culterHelper.SetCulter();
        }
    }
    static float GetTemperatureUnit()
    {
        string message = string.Empty;
        int temperatureUnit;
        message = CultureInformation.GetCultureInformation().GetString("TemperatureUnit");
        Display.PrintMessage(message);
        temperatureUnit = Convert.ToInt32(Console.ReadLine());
        return GetTemperatureValue(temperatureUnit);
    }
    static float GetTemperatureValue(int tempUnit)
    {
        string message = string.Empty;
        message = CultureInformation.GetCultureInformation().GetString("TemperatureValue");
        Display.PrintMessage(message);
        if (tempUnit == 1)
        {
            return float.Parse(Console.ReadLine());
        }
        else
        {
            return BatteryFeatureConversion.ConvertTemperatureFahrenheitToCelsius(float.Parse(Console.ReadLine()));
        }
    }
    static float GetStateOfChargeInput()
    {
        string message = string.Empty;
        message = CultureInformation.GetCultureInformation().GetString("StateOfChargeValue");
        Display.PrintMessage(message);
        return float.Parse(Console.ReadLine());
    }
    static float GetChargeRateInput()
    {
        string message = string.Empty;
        message = CultureInformation.GetCultureInformation().GetString("ChargeRateValue");
        Display.PrintMessage(message);
        return float.Parse(Console.ReadLine());

    }

}

