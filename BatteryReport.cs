using System;
using System.Collections.Generic;
using System.Text;

public class BatteryReport
{
    private readonly IReports _iReports;
    public BatteryReport(IReports iReports)
    {
        this._iReports = iReports;
    }
    public void ReportLogger(Dictionary<string, string> alertMaster)
    {
        this._iReports.DisplayBatteryReport(alertMaster);
    }
}

