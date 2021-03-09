using System;
using System.Collections.Generic;
using System.Text;

public static class BatteryLimits 
{
    private static IReadOnlyDictionary<Interval, Tuple<string,string>> _stateOfChargeBoundary
    = new Dictionary<Interval, Tuple<string, string>>
       {
           { new Interval(0, 20), new Tuple<string,string>("The state of charge is low compared to the minimum limits","Der Ladezustand ist im Vergleich zu den Mindestgrenzen niedrig") },
           { new Interval(21, 24), new Tuple<string,string>("Warning! State of charge is heading towards minimum limit value","Warnung! Der Ladezustand nähert sich dem Mindestgrenzwert") },
           { new Interval(25, 75), new Tuple<string,string>("State of Charge is Normal","Der Ladezustand ist normal")},
           { new Interval(76, 80), new Tuple<string,string>("Warning! State of charge is heading towards maximum limit value","Warnung! Der Ladezustand nähert sich dem maximalen Grenzwert") },
           { new Interval(81, 100), new Tuple<string,string>("The state of charge is high compared to the maximum limits","Der Ladezustand ist im Vergleich zu den Höchstgrenzen hoch") }
        };
    public static IReadOnlyDictionary<Interval, Tuple<string, string>> stateOfChargeBoundary => _stateOfChargeBoundary;

   private static IReadOnlyDictionary<Interval, Tuple<string, string>> _temperatureBoundary
   = new Dictionary<Interval, Tuple<string, string>>
      {
           { new Interval(-45, -0.01f), new Tuple<string,string>("The temperature is low compared to the minimum limits","Die Temperatur ist im Vergleich zu den Mindestgrenzwerten niedrig") },
           { new Interval(0, 2.25f), new Tuple<string,string>("Warning! Temperature is heading towards minimum limit value","Warnung! Die Temperatur nähert sich dem Mindestgrenzwert") },
           { new Interval(2.26f, 42.75f), new Tuple<string,string>("Temperature is Normal","Die Temperatur ist normal")},
           { new Interval(42.76f, 45), new Tuple<string,string>("Warning! Temperature is heading towards maximum limit value","Warnung! Die Temperatur nähert sich dem maximalen Grenzwert") },
           { new Interval(46, 100), new Tuple<string,string>("The temperature is high compared to the maximum limits","Die Temperatur ist im Vergleich zu den Höchstgrenzen hoch") }
       };
    public static IReadOnlyDictionary<Interval, Tuple<string, string>> temperatureBoundary => _temperatureBoundary;

    private static IReadOnlyDictionary<Interval, Tuple<string, string>> _chargeRateBoundary
   = new Dictionary<Interval, Tuple<string, string>>
      {
           { new Interval(0, 0.75f), new Tuple<string,string>("Charge Rate is Normal","Laderate ist normal")},
           { new Interval(0.76f, 0.8f), new Tuple<string,string>("Warning! Charge rate is heading towards maximum limit value","Warnung! Der Gebührensatz bewegt sich in Richtung des maximalen Grenzwerts") },
           { new Interval(0.81f, 100), new Tuple<string,string>("The charge rate is high compared to the maximum limits","Die Laderate ist im Vergleich zu den Höchstgrenzen hoch") }
       };
    public static IReadOnlyDictionary<Interval, Tuple<string, string>> chargeRateBoundary => _chargeRateBoundary;

}

