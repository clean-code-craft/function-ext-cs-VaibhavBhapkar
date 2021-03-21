using System;
using System.Collections.Generic;
using System.Text;

public static class BatteryLimits
{

    private static IReadOnlyDictionary<Interval, Tuple<string, BatteryFactors.BatteryStatus>> _stateOfChargeBoundary
    = new Dictionary<Interval, Tuple<string, BatteryFactors.BatteryStatus>>
       {
           { new Interval(0, 20), new Tuple<string,BatteryFactors.BatteryStatus>(CultureInformation.GetCultureInformation().GetString("Low_Soc"),BatteryFactors.BatteryStatus.Breach) },
           { new Interval(21, 24), new Tuple<string,BatteryFactors.BatteryStatus>(CultureInformation.GetCultureInformation().GetString("Warning_Soc_Low"),BatteryFactors.BatteryStatus.Warning) },
           { new Interval(25, 75), new Tuple<string,BatteryFactors.BatteryStatus>(CultureInformation.GetCultureInformation().GetString("Normal_Soc"),BatteryFactors.BatteryStatus.Normal)},
           { new Interval(76, 80), new Tuple<string,BatteryFactors.BatteryStatus>(CultureInformation.GetCultureInformation().GetString("Warning_Soc_High"),BatteryFactors.BatteryStatus.Warning) },
           { new Interval(81, 100), new Tuple<string,BatteryFactors.BatteryStatus>(CultureInformation.GetCultureInformation().GetString("High_Soc"),BatteryFactors.BatteryStatus.Breach) }
        };
    public static IReadOnlyDictionary<Interval, Tuple<string, BatteryFactors.BatteryStatus>> stateOfChargeBoundary => _stateOfChargeBoundary;

    private static IReadOnlyDictionary<Interval, Tuple<string, BatteryFactors.BatteryStatus>> _temperatureBoundary
    = new Dictionary<Interval, Tuple<string, BatteryFactors.BatteryStatus>>
       {
           { new Interval(-45, -0.01f), new Tuple<string,BatteryFactors.BatteryStatus>(CultureInformation.GetCultureInformation().GetString("Low_Temperature"),BatteryFactors.BatteryStatus.Breach) },
           { new Interval(0, 2.25f), new Tuple<string,BatteryFactors.BatteryStatus>(CultureInformation.GetCultureInformation().GetString("Warning_Temperature_Low"),BatteryFactors.BatteryStatus.Warning) },
           { new Interval(2.26f, 42.75f), new Tuple<string,BatteryFactors.BatteryStatus>(CultureInformation.GetCultureInformation().GetString("Normal_Temperature"),BatteryFactors.BatteryStatus.Normal)},
           { new Interval(42.76f, 45), new Tuple<string,BatteryFactors.BatteryStatus>(CultureInformation.GetCultureInformation().GetString("Warning_Temperature_High"),BatteryFactors.BatteryStatus.Warning) },
           { new Interval(46, 100), new Tuple<string,BatteryFactors.BatteryStatus>(CultureInformation.GetCultureInformation().GetString("High_Temperature"),BatteryFactors.BatteryStatus.Breach) }
        };
    public static IReadOnlyDictionary<Interval, Tuple<string, BatteryFactors.BatteryStatus>> temperatureBoundary => _temperatureBoundary;

    private static IReadOnlyDictionary<Interval, Tuple<string, BatteryFactors.BatteryStatus>> _chargeRateBoundary
   = new Dictionary<Interval, Tuple<string, BatteryFactors.BatteryStatus>>
      {
           { new Interval(0, 0.75f), new Tuple<string,BatteryFactors.BatteryStatus>(CultureInformation.GetCultureInformation().GetString("Normal_ChargeRate"),BatteryFactors.BatteryStatus.Normal)},
           { new Interval(0.76f, 0.8f), new Tuple<string,BatteryFactors.BatteryStatus>(CultureInformation.GetCultureInformation().GetString("Warning_ChargeRate_High"),BatteryFactors.BatteryStatus.Warning) },
           { new Interval(0.81f, 100), new Tuple<string,BatteryFactors.BatteryStatus>(CultureInformation.GetCultureInformation().GetString("High_ChargeRate"),BatteryFactors.BatteryStatus.Breach) }
       };
    public static IReadOnlyDictionary<Interval, Tuple<string, BatteryFactors.BatteryStatus>> chargeRateBoundary => _chargeRateBoundary;

}

