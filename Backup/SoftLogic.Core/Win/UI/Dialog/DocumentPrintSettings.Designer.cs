namespace SoftLogik.Win.UI.Controls
{
    public partial class PrintSettings : System.ComponentModel.Component
    {

        [System.Diagnostics.DebuggerNonUserCode()]
        public PrintSettings(System.ComponentModel.IContainer Container)
            : this()
        //TODO: INSTANT C# TODO TASK: C# does not have an equivalent to VB.NET's 'MyClass' keyword
        //ORIGINAL LINE: MyClass.New()
        {

            //Required for Windows.Forms Class Composition Designer support
            Container.Add(this);

        }

        [System.Diagnostics.DebuggerNonUserCode()]
        public PrintSettings()
            : base()
        {

            //This call is required by the Component Designer.
            InitializeComponent();

        }

        //Component overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        //Required by the Component Designer
        private System.ComponentModel.IContainer components;

        //NOTE: The following procedure is required by the Component Designer
        //It can be modified using the Component Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.MyPrintDialog = new System.Windows.Forms.PrintDialog();
            //
            //MyPrintDialog
            //
            this.MyPrintDialog.UseEXDialog = true;

        }
        internal System.Windows.Forms.PrintDialog MyPrintDialog;

    }
}