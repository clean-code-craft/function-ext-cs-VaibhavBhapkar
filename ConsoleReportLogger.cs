using System;
using System.Collections.Generic;
using System.Text;
public class ConsoleReportLogger : IReports
{
    public void DisplayBatteryReport(Dictionary<string, string> batteryAlerts)
    {
        Display.PrintMessage("\n**** Battery Health Report - Breached factors Details *****");
        foreach (var alertMessage in batteryAlerts)
        {
            Display.PrintMessage(alertMessage.Key);
            Display.PrintMessage(alertMessage.Value);
        }
    }
}

