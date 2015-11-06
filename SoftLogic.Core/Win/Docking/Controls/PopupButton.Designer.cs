internal partial class PopupButton : System.Windows.Forms.Button
{

	//UserControl overrides dispose to clean up the component list.
	internal PopupButton()
	{
		InitializeComponent();
	}
	[System.Diagnostics.DebuggerNonUserCode()]
	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		components = new System.ComponentModel.Container();
	}

}
