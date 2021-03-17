using System;
using System.Collections.Generic;
using System.Text;


public class BatteryFactors
{
    public float batteryTemprature, batteryStateOfCharge, batteryChargeRate;
    public string operatingLanguage = string.Empty, temperatureMesureUnit=string.Empty;
    public BatteryFactors(float temprature, float soc, float chargeRate, string operatingLang,string temperatureMesureUnit)
    {
        this.batteryTemprature = temprature;
        this.batteryStateOfCharge = soc;
        this.batteryChargeRate = chargeRate;
        this.operatingLanguage = operatingLang;
        this.temperatureMesureUnit = temperatureMesureUnit;
    }
}
