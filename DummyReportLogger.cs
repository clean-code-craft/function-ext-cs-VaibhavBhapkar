using System;
using System.Collections.Generic;
using System.Text;


public class DummyReportLogger : IReports
{
    public void DisplayBatteryReport(Dictionary<string, string> batteryAlerts)
    {
        Display.PrintMessage("\n**** Another Reporting Feature ****");
    }
}

