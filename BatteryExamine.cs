using System;
using System.Collections.Generic;
using System.Text;

public class BatteryExamine
{
    public bool BatteryIsOk(BatteryFactors batteryFactors)
    {
        bool temperatureStatus, socStatus, chargeRateStatus;
        temperatureStatus = CompareTemperatureWithRange(batteryFactors.batteryTemprature);
        socStatus = CompareStateOfChargeWithRange(batteryFactors.batteryStateOfCharge);
        chargeRateStatus = CompareChargeRateWithRange(batteryFactors.batteryChargeRate);
        return (temperatureStatus && socStatus && chargeRateStatus);
    }
    private bool CompareTemperatureWithRange(float batteryTemperature)
    {
        foreach (var temperatureValue in BatteryLimits.temperatureBoundary)
        {
            if (temperatureValue.Key.InRange(batteryTemperature))
            {
                Display.PrintMessage(temperatureValue.Value.Item1);
                if (temperatureValue.Value.Item2 != BatteryFactors.BatteryStatus.Breach)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public bool CompareStateOfChargeWithRange(float stateOfCharge)
    {
        foreach (var socValue in BatteryLimits.stateOfChargeBoundary)
        {
            if (socValue.Key.InRange(stateOfCharge))
            {
                Display.PrintMessage(socValue.Value.Item1);
                if (socValue.Value.Item2 != BatteryFactors.BatteryStatus.Breach)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public bool CompareChargeRateWithRange(float chargeRate)
    {
        foreach (var chargeRateValue in BatteryLimits.chargeRateBoundary)
        {
            if (chargeRateValue.Key.InRange(chargeRate))
            {
                Display.PrintMessage(chargeRateValue.Value.Item1);
                if (chargeRateValue.Value.Item2 != BatteryFactors.BatteryStatus.Breach)
                {
                    return true;
                }
            }
        }
        return false;
    }
}

