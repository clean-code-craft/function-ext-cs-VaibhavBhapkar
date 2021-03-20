using System;
using System.Collections.Generic;
using System.Text;

public class BatteryExamine
{
    public bool BatteryIsOk(BatteryFactors batteryFactors)
    {
        BatteryFactors.BatteryStatus temperatureStatus, socStatus, chargeRateStatus;
        temperatureStatus=CompareTemperatureWithRange(batteryFactors.batteryTemprature);
        socStatus=CompareStateOfChargeWithRange(batteryFactors.batteryStateOfCharge);
        chargeRateStatus=CompareChargeRateWithRange(batteryFactors.batteryChargeRate);
        if(temperatureStatus== BatteryFactors.BatteryStatus.Normal && socStatus == BatteryFactors.BatteryStatus.Normal &&chargeRateStatus == BatteryFactors.BatteryStatus.Normal)
        {
            return true;
        }
        return false;
    }
    private BatteryFactors.BatteryStatus CompareTemperatureWithRange(float batteryTemperature)
    {
        foreach (var temperatureValue in BatteryLimits.temperatureBoundary)
        {
            if (temperatureValue.Key.InRange(batteryTemperature))            
            {
                Display.PrintMessage(temperatureValue.Value.Item1);
                return temperatureValue.Value.Item2;
            }
        }
        return BatteryFactors.BatteryStatus.Breach;
    }
    public BatteryFactors.BatteryStatus CompareStateOfChargeWithRange(float stateOfCharge)
    {
        foreach (var socValue in BatteryLimits.stateOfChargeBoundary)
        {
            if (socValue.Key.InRange(stateOfCharge))
            {
                Display.PrintMessage(socValue.Value.Item1);
                return socValue.Value.Item2;
            }
        }
        return BatteryFactors.BatteryStatus.Breach;
    }
    public BatteryFactors.BatteryStatus CompareChargeRateWithRange(float chargeRate)
    {
        foreach (var chargeRateValue in BatteryLimits.chargeRateBoundary)
        {
            if (chargeRateValue.Key.InRange(chargeRate))
            {
                Display.PrintMessage(chargeRateValue.Value.Item1);
                return chargeRateValue.Value.Item2;
            }
        }
        return BatteryFactors.BatteryStatus.Breach;
    }  
}

