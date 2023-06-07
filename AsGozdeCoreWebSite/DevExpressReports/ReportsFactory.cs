using AsGozdeCoreWebSite.DevExpressReports;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
public class ReportsFactory
{
    public static Dictionary<string, Func<XtraReport>> Reports = new Dictionary<string, Func<XtraReport>>()
    {
        ["DesignReport"] = () => new DesignReport()
    };
}