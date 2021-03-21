using System;
using System.Collections.Generic;
using System.Text;

public static class BatteryFeatureConversion
{
    public static float ConvertTemperatureFahrenheitToCelsius(float fahrenheitTemp)
    {
        return (fahrenheitTemp - 32) * 5 / 9;
    }
}

