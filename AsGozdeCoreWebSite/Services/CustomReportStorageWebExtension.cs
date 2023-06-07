using DataAccess.EntityFramework.Context;
using DevExpress.XtraReports.UI;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;



public class CustomReportStorageWebExtension : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
{
    private string connectionString;

    private DataTable reportsTable = new DataTable();
    private SqlDataAdapter reportsTableAdapter;
    //string connectionString = "Data Source=localhost;Initial Catalog=Reports;Integrated Security=True";
    public CustomReportStorageWebExtension(string connectionString)
    {
        this.connectionString = connectionString;

        //reportsTableAdapter = new SqlDataAdapter("Select * from ReportLayout", new SqlConnection(connectionString));
        //SqlCommandBuilder builder = new SqlCommandBuilder(reportsTableAdapter);
        //reportsTableAdapter.InsertCommand = builder.GetInsertCommand();
        //reportsTableAdapter.UpdateCommand = builder.GetUpdateCommand();
        //reportsTableAdapter.DeleteCommand = builder.GetDeleteCommand();
        //reportsTableAdapter.Fill(reportsTable);
        //DataColumn[] keyColumns = new DataColumn[1];
        //keyColumns[0] = reportsTable.Columns[0];
        //reportsTable.PrimaryKey = keyColumns;
    }
    public override bool CanSetData(string url)
    {
        return GetUrls()[url].Contains("ReadOnly") ? false : true;
    }
    public override byte[] GetData(string url)
    {
        // Get the report data from the storage.
        DataRow row = reportsTable.Rows.Find(int.Parse(url));
        if (row == null) return null;

        byte[] reportData = (Byte[])row["LayoutData"];
        return reportData;
    }
    public override Dictionary<string, string> GetUrls()
    {
        reportsTable.Clear();
        reportsTableAdapter.Fill(reportsTable);
        // Get URLs and display names for all reports available in the storage.
        var v = reportsTable.AsEnumerable()
              .ToDictionary<DataRow, string, string>(dataRow => ((Int32)dataRow["ReportId"]).ToString(),
                                                     dataRow => (string)dataRow["DisplayName"]);
        return v;
    }
    public override bool IsValidUrl(string url)
    {
        return true;
    }
    public override void SetData(XtraReport report, string url)
    {
        // Write a report to the storage under the specified URL.
        DataRow row = reportsTable.Rows.Find(int.Parse(url));
        if (row != null)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                report.SaveLayoutToXml(ms);
                row["LayoutData"] = ms.GetBuffer();
            }
            reportsTableAdapter.Update(reportsTable);
        }
    }
    public override string SetNewData(XtraReport report, string defaultUrl)
    {
        // Append "1" if a new report name already exists.
        if (GetUrls().ContainsValue(defaultUrl)) defaultUrl = string.Concat(defaultUrl, "1");

        // Save a report to the storage with a new URL. 
        // The defaultUrl parameter is the report name that the user specifies.
        DataRow row = reportsTable.NewRow();
        row["ReportId"] = 0;
        row["DisplayName"] = defaultUrl;
        using (MemoryStream ms = new MemoryStream())
        {
            report.SaveLayoutToXml(ms);
            row["LayoutData"] = ms.GetBuffer();
        }
        reportsTable.Rows.Add(row);
        reportsTableAdapter.Update(reportsTable);
        // Refill the dataset to obtain the actual value of the new row's autoincrement key field.
        reportsTable.Clear();
        reportsTableAdapter.Fill(reportsTable);
        return reportsTable.AsEnumerable().
            FirstOrDefault(x => x["DisplayName"].ToString() == defaultUrl)["ReportId"].ToString();
    }
    
}

//public class CustomReportStorageWebExtension : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
//{

//    readonly string ReportDirectory;
//    const string FileExtension = ".repx";
//    public CustomReportStorageWebExtension(IWebHostEnvironment env)
//    {
//        ReportDirectory = Path.Combine(env.ContentRootPath, "DevExpressReports");
//        if (!Directory.Exists(ReportDirectory))
//        {
//            Directory.CreateDirectory(ReportDirectory);
//        }
//    }

//    private bool IsWithinReportsFolder(string url, string folder)
//    {
//        var rootDirectory = new DirectoryInfo(folder);
//        var fileInfo = new FileInfo(Path.Combine(folder, url));
//        return fileInfo.Directory.FullName.ToLower().StartsWith(rootDirectory.FullName.ToLower());
//    }

//    public override bool CanSetData(string url)
//    {
//        // Determines whether or not it is possible to store a report by a given URL. 
//        // For instance, make the CanSetData method return false for reports that should be read-only in your storage. 
//        // This method is called only for valid URLs (i.e., if the IsValidUrl method returns true) before the SetData method is called.

//        return true;
//    }

//    public override bool IsValidUrl(string url)
//    {
//        // Determines whether or not the URL passed to the current Report Storage is valid. 
//        // For instance, implement your own logic to prohibit URLs that contain white spaces or other special characters. 
//        // This method is called before the CanSetData and GetData methods.

//        return Path.GetFileName(url) == url;
//    }

//    public override byte[] GetData(string url)
//    {
//        // Returns report layout data stored in a Report Storage using the specified URL. 
//        // This method is called only for valid URLs after the IsValidUrl method is called.
//        try
//        {
//            if (Directory.EnumerateFiles(ReportDirectory).Select(Path.GetFileNameWithoutExtension).Contains(url))
//            {
//                return File.ReadAllBytes(Path.Combine(ReportDirectory, url + FileExtension));
//            }
//            if (ReportsFactory.Reports.ContainsKey(url))
//            {
//                using (MemoryStream ms = new MemoryStream())
//                {
//                    ReportsFactory.Reports[url]().SaveLayoutToXml(ms);
//                    return ms.ToArray();
//                }
//            }
//        }
//        catch (Exception ex)
//        {
//            throw new DevExpress.XtraReports.Web.ClientControls.FaultException("Could not get report data.", ex);
//        }
//        throw new DevExpress.XtraReports.Web.ClientControls.FaultException(string.Format("Could not find report '{0}'.", url));
//    }

//    public override Dictionary<string, string> GetUrls()
//    {
//        // Returns a dictionary of the existing report URLs and display names. 
//        // This method is called when running the Report Designer, 
//        // before the Open Report and Save Report dialogs are shown and after a new report is saved to a storage.

//        return Directory.GetFiles(ReportDirectory, "*" + FileExtension)
//                                .Select(Path.GetFileNameWithoutExtension)
//                                .Union(ReportsFactory.Reports.Select(x => x.Key))
//                                .ToDictionary<string, string>(x => x);
//    }

//    public override void SetData(XtraReport report, string url)
//    {
//        // Stores the specified report to a Report Storage using the specified URL. 
//        // This method is called only after the IsValidUrl and CanSetData methods are called.
//        if (!IsWithinReportsFolder(url, ReportDirectory))
//            throw new DevExpress.XtraReports.Web.ClientControls.FaultException("Invalid report name.");
//        report.SaveLayoutToXml(Path.Combine(ReportDirectory, url + FileExtension));
//    }

//    public override string SetNewData(XtraReport report, string defaultUrl)
//    {
//        // Stores the specified report using a new URL. 
//        // The IsValidUrl and CanSetData methods are never called before this method. 
//        // You can validate and correct the specified URL directly in the SetNewData method implementation 
//        // and return the resulting URL used to save a report in your storage.
//        SetData(report, defaultUrl);
//        return defaultUrl;
//    }


//}