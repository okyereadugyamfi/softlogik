namespace SoftLogik.Win.UI.Controls
{
    public partial class PrintSettings
    {


    }




    public static class PrintSupport
    {

        private static PrintSettings m_PrintSettings = new PrintSettings();

        public static bool ChoosePrinter()
        {
            m_PrintSettings.MyPrintDialog.ShowDialog();
            //INSTANT C# NOTE: Inserted the following 'return' since all code paths must return a value in C#:
            return false;
        }
    }
}