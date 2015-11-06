using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftLogic.Web.Presentation.Support
{
    public class File
    {
        public static string SaveFileCopy(FileUpload FileSource)
        {
            return SaveFileCopy(FileSource, SaveFileLocations.TempDirectory);
        }

        public static string SaveFileCopy(FileUpload FileSource, SaveFileLocations SaveFileLocation)
        {

            string FileName = string.Empty;
            string OldFileName = FileSource.FileName;
            string SaveLocation = string.Empty;
            if (SaveFileLocation == SaveFileLocations.TCEDirectory)
            {
                SaveLocation = "tceDir";
            }
            else if (SaveFileLocation == SaveFileLocations.TempDirectory)
            {
                SaveLocation = "tempDir";
            }
            else if (SaveFileLocation == SaveFileLocations.NewsDirectory)
            {
                SaveLocation = "newsDir";
            }
            else if (SaveFileLocation == SaveFileLocations.AttachmentsDirectory)
            {
                SaveLocation = "attachDir";
            }
            FileName = Path.Combine(HttpContext.Current.Request.MapPath(ConfigurationManager.AppSettings[SaveLocation].ToString()), Path.GetFileName(OldFileName));

            if (!(Directory.Exists(Path.GetDirectoryName(FileName))))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FileName));
            }

            if (File.Exists(FileName))
            {
                try
                {
                    File.Delete(FileName);
                }
                catch (Exception ex)
                {
                }
            }

            try
            {
                FileSource.PostedFile.SaveAs(FileName);
            }
            catch (Exception ex)
            {
                throw;
            }

            return FileName;
        }

        public static string SaveFileCopy(string FileContent, string FileName)
        {
            string SaveLocation = "tempDir";
            FileName = Path.Combine(HttpContext.Current.Request.MapPath(ConfigurationManager.AppSettings[SaveLocation].ToString()), Path.GetFileName(FileName));

            if (!(Directory.Exists(Path.GetDirectoryName(FileName))))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FileName));
            }

            if (File.Exists(FileName))
            {
                try
                {
                    File.Delete(FileName);
                }
                catch (Exception ex)
                {
                }
            }

            StreamWriter aFile = new StreamWriter(FileName, false);
            aFile.AutoFlush = true;
            aFile.Write(FileContent);
            aFile.Close();

            return FileName;

        }
        public static string SaveFileCopy(byte[] FileContent, string FileName)
        {
            string SaveLocation = "tempDir";
            FileName = Path.Combine(HttpContext.Current.Request.MapPath(ConfigurationManager.AppSettings[SaveLocation].ToString()), Path.GetFileName(FileName));

            if (!(Directory.Exists(Path.GetDirectoryName(FileName))))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(FileName));
            }

            if (File.Exists(FileName))
            {
                try
                {
                    File.Delete(FileName);
                }
                catch (Exception ex)
                {
                }
            }

            MemoryStream memFile = new MemoryStream(FileContent);
            StreamWriter aFile = new StreamWriter(FileName);
            memFile.WriteTo(aFile.BaseStream);
            aFile.Flush();
            aFile.Close();
            return FileName;
        }
    }
}
