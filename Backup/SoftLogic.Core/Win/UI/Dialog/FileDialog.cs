using System;
using System.Windows.Forms; 

namespace SoftLogik.Win.UI.Controls
{
    public partial class FileDialog
    {

        public enum FileDialogTypes : int
        {
            General = 0,
            Picture,
            OfficeDocument,
            Video,
            Audio

        }

        public static string ShowDialog(FileDialogTypes FileType)
        {

            try
            {
                using (OpenFileDialog myFileDialog = new OpenFileDialog())
                {
                    myFileDialog.Filter = GetFilters(FileType);
                    if (myFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        return myFileDialog.FileName;
                    }

                }

            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public static string[] ShowMultiDialog(FileDialogTypes FileType)
        {

            try
            {
                using (OpenFileDialog myFileDialog = new OpenFileDialog())
                {
                    if (myFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        return myFileDialog.FileNames;
                    }

                }

            }
            catch (Exception ex)
            {
            }
            return null;
        }

        private static string GetFilters(FileDialogTypes filetype)
        {
            switch (filetype)
            {
                case FileDialogTypes.Picture:
                    return "All Picture Files(*.jpeg,*.jpe,*.jpg,*.gif,*.png,*.bmp,*.wmf,*.ico)|*.jpeg;*.jpe;*.jpg;*.gif;*.png;*.bmp;*.wmf;*.ico|JPEG Files(*.jpg,*.jpe,*.jpeg)|*.jpg;*.jpe;*.jpeg";
                default:
                    return "All Files(*.*)|*.*";
            }

            return null;
        }
    }
}