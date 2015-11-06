namespace SoftLogik.Win.UI.Controls
{
    public partial class FileDialog : System.ComponentModel.Component
    {

        [System.Diagnostics.DebuggerNonUserCode()]
        public FileDialog(System.ComponentModel.IContainer container)
            : this()
        //TODO: INSTANT C# TODO TASK: C# does not have an equivalent to VB.NET's 'MyClass' keyword
        //ORIGINAL LINE: MyClass.New()
        {

            //Required for Windows.Forms Class Composition Designer support
            if (container != null)
            {
                container.Add(this);
            }

        }

        [System.Diagnostics.DebuggerNonUserCode()]
        public FileDialog()
            : base()
        {

            //This call is required by the Component Designer.
            InitializeComponent();

        }

        //Component overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        //Required by the Component Designer
        private System.ComponentModel.IContainer components;

        //NOTE: The following procedure is required by the Component Designer
        //It can be modified using the Component Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {

        }

    }

}
