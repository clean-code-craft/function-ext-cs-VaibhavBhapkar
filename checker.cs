using System;
using System.Collections.Generic;

class Checker
{
    static void Main()
    {
        BatteryExamine batteryExamine = new BatteryExamine();

        Dictionary<string, string> batteryAlertMessages = batteryExamine.BatteryIsOk(new BatteryFactors(100, 80, 0.2f, "English", "Celsius"));
        IReports iReportsCosoleLogger = new ConsoleReportLogger();
        BatteryReport batteryReportWithConsoleLogger = new BatteryReport(iReportsCosoleLogger);
        batteryReportWithConsoleLogger.ReportLogger(batteryAlertMessages);
        IReports iReportsDummyLogger = new DummyReportLogger();
        BatteryReport batteryReportWithDummyLogger = new BatteryReport(iReportsDummyLogger);
        batteryReportWithDummyLogger.ReportLogger(batteryAlertMessages);

        Dictionary<string, string> batteryAlertMessagesTest = batteryExamine.BatteryIsOk(new BatteryFactors(100, 85, 0.2f, "German", "Fahrenheit"));
        IReports iReportsCosoleLoggerTest = new ConsoleReportLogger();
        BatteryReport batteryReportWithConsoleLoggerTest = new BatteryReport(iReportsCosoleLoggerTest);
        batteryReportWithConsoleLoggerTest.ReportLogger(batteryAlertMessagesTest);
        IReports iReportsDummyLoggerTest = new DummyReportLogger();
        BatteryReport batteryReportWithDummyLoggerTest = new BatteryReport(iReportsDummyLoggerTest);
        batteryReportWithDummyLoggerTest.ReportLogger(batteryAlertMessagesTest);
    }    
}

