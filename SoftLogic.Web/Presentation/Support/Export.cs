using System;
using System.Web.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftLogic.Web.Presentation.Support
{
    public class Export
    {
        public static boid ExportToExcel(Control SourceData, string FileName)
        {
            ExportToExcel(SourceData, FileName, false);
        }

        /// <summary>
        /// Exports data supplied
        /// </summary>
        /// <param name="SourceData"></param>
        /// <param name="FileName"></param>
        /// <param name="PerfomNameMangle"></param>
        /// <returns></returns>
        public static void ExportToExcel(Control SourceData, string FileName, bool PerfomNameMangle)
        {
            try
            {
                HttpContext.Current.Session.Remove("exportReportData");
                System.IO.StringWriter stringWrite = new System.IO.StringWriter();
                System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                SourceData.RenderControl(htmlWrite);
                HttpContext.Current.Session["exportReportData"] = stringWrite.ToString();
                HttpContext.Current.Response.Redirect("~/portal/shared/exportReport.aspx?f=" + GetExcelFileName(Path.GetFileNameWithoutExtension(FileName), PerfomNameMangle), false);
            }
            catch (Exception ex)
            {
            }
        }

        public string GetExcelFileName(string ReportName)
        {
            return GetExcelFileName(ReportName, false);
        }

        public string GetExcelFileName(string ReportName, bool PerfomNameMangle)
        {
            System.DateTime currentDate = System.DateTime.Now;
            if (PerfomNameMangle)
            {
                return ReportName + "_" + currentDate.Year + currentDate.Month.ToString("00") + currentDate.Day.ToString("00") + ".xls";
            }
            else
            {
                return ReportName.Trim() + ".xls";
            }
        }
    }
}
