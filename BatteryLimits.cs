using System;
using System.Collections.Generic;
using System.Text;

public static class BatteryLimits 
{
    private static IReadOnlyDictionary<Interval<float>, string> _stateOfChargeBoundary
    = new Dictionary<Interval<float>, string>
       {
           { new Interval<float>(0, 20), "LOW_SOC_BREACH" },
           { new Interval<float>(21, 24), "LOW_SOC_WARNING" },
           { new Interval<float>(25, 75), "NORMAL"},
           { new Interval<float>(76, 80), "HIGH_SOC_WARNING" },
           { new Interval<float>(81, 100), "HIGH_SOC_BREACH" }
        };
    public static IReadOnlyDictionary<Interval<float>, string> stateOfChargeBoundary => _stateOfChargeBoundary;

   private static IReadOnlyDictionary<Interval<float>, string> _temperatureBoundary
   = new Dictionary<Interval<float>, string>
      {
           { new Interval<float>(-45, -2.26f), "LOW_TEMPERATURE_BREACH" },
           { new Interval<float>(-2.25f, -1), "LOW_TEMPERATURE_WARNING" },
           { new Interval<float>(0, 42.75f), "NORMAL"},
           { new Interval<float>(42.76f, 45), "HIGH_TEMPERATURE_WARNING" },
           { new Interval<float>(46, 100), "HIGH_TEMPERATURE_BREACH" }
       };
    public static IReadOnlyDictionary<Interval<float>, string> temperatureBoundary => _temperatureBoundary;

    private static IReadOnlyDictionary<Interval<float>, string> _chargeRateBoundary
   = new Dictionary<Interval<float>, string>
      {
           { new Interval<float>(0, 0.75f), "NORMAL"},
           { new Interval<float>(0.76f, 0.8f), "HIGH_CHARGERATE_WARNING" },
           { new Interval<float>(0.81f, 100), "HIGH_CHARGERATE_BREACH" }
       };
    public static IReadOnlyDictionary<Interval<float>, string> chargeRateBoundary => _chargeRateBoundary;

}

